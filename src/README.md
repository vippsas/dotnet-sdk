# Paket
This project uses [Paket](https://fsprojects.github.io/Paket/) for dependency management. To install dependencies, run the following command from the repo's root directory:
```shell
  paket install 
```

# Developer tools
To use Husky pre-commit hooks (e.g. for CSharpier), run the command from the repo's root directory: 
```shell
dotnet husky add pre-commit -c "dotnet husky run"
```
