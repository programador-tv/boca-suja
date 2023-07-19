# 🧼🤬 boca-suja
projeto aberto que visa criar uma solução simples para gerenciar conteúdo de texto inapropriado em aplicações

## 📍 Como executar o projeto

### 🏠 local

- pré-requisitos:
    - .NET8
    - CSharpier (https://csharpier.com/docs/Installation)

```
    cd Apps/Web.Api.BocaSuja
    dotnet run
```

### 🐳 docker & docker compose

- pré-requisitos:
    - Docker & docker compose

```
    cd devops/docker
    docker compose up 
```

### 🚢 kubernetes

- pré-requisitos:
    - Docker & docker compose
    - kubectl (https://kubernetes.io/docs/tasks/tools/)
    - Minikube (https://minikube.sigs.k8s.io/docs/start/) para desenvolvimento local
    - Cluster Kubernetes para ambientes em nuvem

```
    cd devops/docker
    docker compose build
    cd ../k8s
    kubectl apply -f . 
```



## 🧪 Executar os testes

```
    dotnet test
```



## 🤝 Contribuições
Ainda estamos criando um passo a passo de como contribuir! De qualquer forma convido voçê a entrar no slack do programador.tv onde há um forum de discussão a respeito do projeto 

- [Slack](https://join.slack.com/t/programadortv/shared_invite/zt-1xio6zmch-ExATgTVI808YsqY2IZdvjA](https://join.slack.com/t/programadortv/shared_invite/zt-1zfi7uzom-atVA8mJeIMF4pk4SEI1Ghw)https://join.slack.com/t/programadortv/shared_invite/zt-1zfi7uzom-atVA8mJeIMF4pk4SEI1Ghw)
