# Projeto questionário

## Configurações antes de executar

Configurar a connection string no arquivo appsettings.json

```json
"ConnectionStrings": {
    "QuestionarioBackendContext": "Server=<Server>;Database=<Database>;"
}
```

Abrir o terminal e execute essas duas linhas:

```bash
  dotnet ef migrations add InitialCreate
  dotnet ef database update
```
