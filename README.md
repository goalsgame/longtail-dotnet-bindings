### Builds
[![Build and Test CodeGen](https://github.com/Golle/longtail/actions/workflows/build.yml/badge.svg)](https://github.com/Golle/longtail/actions/workflows/build.yml)   
[![Run longtail tests](https://github.com/Golle/longtail/actions/workflows/longtail.yml/badge.svg)](https://github.com/Golle/longtail/actions/workflows/longtail.yml)

### Nuget
(This is a pre-release, some APIs are missing and some error handling are inconsistent)
![Nuget (with prereleases)](https://img.shields.io/nuget/vpre/Longtail) 


## Longtail C# Bindings

This project generates cross platform C# bindings for Dan Engelbrecht longtail library. [Longtail](https://github.com/DanEngelbrecht/longtail).


## How to
### BuildTool
Run the entire build pipeline to sync with the latest version of Longtail. 
Delete the LONGTAIL_VERSION file in the root folder of the repo to force the pipeline to run.
```powershell
.\build.ps1     # windows
./build.sh      # mac/linux
```

## Current status
Version 0.3.2 of longtail

**Implemented**
* Generates bindings for all structs, enums, functions, function pointers
* Supports .NET5.0 and .NET 6.0 on platforms Linux, MacOS and Windows x64
* Automatic documentation for function pointers with the original names of parameters

**Working on**
* Copy the comments from the API functions and generate C# comments in the LongtailLibrary.cs file
* Nuget package for the low level bindings (Unsafe)
* Managed abstrations (hide all unsafe code behind easy to use managed functions and classes)
* More tests for both CodeGen and Longtail

**Known issues**
* Currently using type `ulong` for `size_t`. This works but it's not correct, it should be `nuint` (or `UIntPtr` in older versions of .NET)
* Hardcoded paths for longtail inside code gen (can be overriden with calling the project with arguments)

Comments on function pointers might be a bit different from original. This happens because it binds the type to the parent.
```csharp
// The comment
// int Longtail_BlockStore_PreflightGetFunc(struct Longtail_BlockStoreAPI* block_store_api, unsigned int block_count, const unsigned long long int* block_hashes, struct Longtail_AsyncPreflightStartedAPI* optional_async_complete_api)

// The c# code
public delegate* unmanaged[Cdecl]<Longtail_BlockStoreAPI*, uint, ulong*, Longtail_AsyncPreflightStartedAPI*, int> PreflightGet;
```
```c
// The original function pointer
typedef int (*Longtail_BlockStore_PreflightGetFunc)(struct Longtail_BlockStoreAPI* block_store_api, uint32_t block_count, const TLongtail_Hash* block_hashes, struct Longtail_AsyncPreflightStartedAPI* optional_async_complete_api);
```
## Project structure

#### src/BuildTool
* Tool to update dll/so files and run the code gen on the latest version from github.

#### src/CodeGen
* Parser, bindings, type handling etc

#### src/Longtail
* Extensions and helpers for the generated bindings. These are updated manually.

#### src/Longtail/Generated
* Longtail.cs contains all structs, enums etc
* LongtailLibrary.cs contains all the longtail functions found in longtail.h (and all other h files in the repo)

