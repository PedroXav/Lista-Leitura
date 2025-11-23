# 📚 Sistema de Gerenciamento de Leitura

Este projeto implementa um **CRUD completo** para gerenciamento de livros, utilizando:
- **Web API em .NET** com banco de dados **SQLite**
- **DLL de validação** para regras de negócio
- **Página Web (HTML, CSS e JavaScript)** para interação com o usuário

---

## 🚀 Funcionalidades

- **Cadastrar livros** com título, autor e status (Não lido, Lendo, Lido)
- **Listar livros** organizados em colunas por status
- **Editar livros** diretamente na interface
- **Excluir livros** com atualização imediata da lista
- **Validação**: título e autor devem ter pelo menos 3 caracteres
- **Mensagens de erro** exibidas diretamente na página

---

## 🛠️ Tecnologias Utilizadas

- **Back-end**: ASP.NET Core Web API  
- **Banco de dados**: SQLite  
- **Validação**: DLL externa (`ValidadorLivro`)  
- **Front-end**: HTML5, CSS3 e JavaScript puro  
