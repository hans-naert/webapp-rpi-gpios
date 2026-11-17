# webapp-rpi-gpios

## Restore client-side libraries with LibMan

This project uses LibMan (Library Manager) to download the browser-side libraries listed in [`libman.json`](./libman.json) into `wwwroot/lib`.

### Install LibMan

Install the .NET SDK, then install the LibMan CLI as a global .NET tool:

```sh
dotnet tool install -g Microsoft.Web.LibraryManager.Cli
```

If the CLI is already installed, update it with:

```sh
dotnet tool update -g Microsoft.Web.LibraryManager.Cli
```

Check that it is available:

```sh
libman --version
```

### Download the libraries

From the repository root, run:

```sh
libman restore
```

LibMan reads `libman.json` and downloads the pinned versions from cdnjs into their configured `wwwroot/lib` directories. Run this after cloning the repository, or whenever you change the library definitions. The generated library files are ignored by Git.

For LibMan command details, see [Microsoft's LibMan CLI documentation](https://learn.microsoft.com/en-us/aspnet/core/client-side/libman/libman-cli).
