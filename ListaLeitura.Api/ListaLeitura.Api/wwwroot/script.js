const apiUrl = "https://localhost:7113/api/Livros"; // ajuste se sua porta for diferente

// Função para carregar livros
async function carregarLivros() {
    const resposta = await fetch(apiUrl);
    if (!resposta.ok) {
        console.error("Erro ao carregar livros:", await resposta.text());
        return;
    }

    const livros = await resposta.json();

    // Limpa listas
    document.getElementById("listaNaoLidos").innerHTML = "";
    document.getElementById("listaLendo").innerHTML = "";
    document.getElementById("listaLidos").innerHTML = "";

    livros.forEach(livro => {
        const li = document.createElement("li");

        li.innerHTML = `
            <div>
                <strong>${livro.titulo}</strong><br>
                <em>Autor:</em> ${livro.autor}
            </div>
        `;

        // Botão editar
        const btnEditar = document.createElement("button");
        btnEditar.textContent = "Editar";
        btnEditar.onclick = async () => {
            const novoTitulo = prompt("Novo título:", livro.titulo);
            const novoAutor = prompt("Novo autor:", livro.autor);
            const novoStatus = prompt("Novo status (0=Não lido, 1=Lendo, 2=Lido):", livro.status);

            if (novoTitulo && novoAutor && novoStatus !== null) {
                const resposta = await fetch(`${apiUrl}/${livro.id}`, {
                    method: "PUT",
                    headers: { "Content-Type": "application/json" },
                    body: JSON.stringify({
                        id: livro.id,
                        titulo: novoTitulo,
                        autor: novoAutor,
                        status: parseInt(novoStatus)
                    })
                });

                if (!resposta.ok) {
                    const erro = await resposta.text();
                    const msgDiv = document.getElementById("mensagemErro");
                    msgDiv.innerText = erro;
                    msgDiv.style.color = "red";
                    return;
                }

                document.getElementById("mensagemErro").innerText = "";
                await carregarLivros();
            }
        };

        // Botão excluir
        const btnExcluir = document.createElement("button");
        btnExcluir.textContent = "Excluir";
        btnExcluir.onclick = async () => {
            const resposta = await fetch(`${apiUrl}/${livro.id}`, { method: "DELETE" });
            if (!resposta.ok) {
                const erro = await resposta.text();
                const msgDiv = document.getElementById("mensagemErro");
                msgDiv.innerText = erro;
                msgDiv.style.color = "red";
                return;
            }
            document.getElementById("mensagemErro").innerText = "";
            await carregarLivros();
        };

        li.appendChild(btnEditar);
        li.appendChild(btnExcluir);

        // Adiciona na coluna correta
        if (livro.status === 0) {
            document.getElementById("listaNaoLidos").appendChild(li);
        } else if (livro.status === 1) {
            document.getElementById("listaLendo").appendChild(li);
        } else if (livro.status === 2) {
            document.getElementById("listaLidos").appendChild(li);
        }
    });
}

// Função para cadastrar livro
document.getElementById("formCadastro").addEventListener("submit", async (e) => {
    e.preventDefault();

    const titulo = document.getElementById("titulo").value;
    const autor = document.getElementById("autor").value;
    const status = parseInt(document.getElementById("status").value);

    const resposta = await fetch(apiUrl, {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify({ titulo, autor, status })
    });

    if (!resposta.ok) {
        const erro = await resposta.text();
        const msgDiv = document.getElementById("mensagemErro");
        msgDiv.innerText = erro;
        msgDiv.style.color = "red";
        return;
    }

    document.getElementById("mensagemErro").innerText = "";
    await carregarLivros();
});

// Carregar ao abrir a página
carregarLivros();
