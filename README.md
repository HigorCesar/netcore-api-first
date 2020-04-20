# API First pets

API First approach based on [OpenAPI code generation](https://openapi-generator.tech/docs/usage/)

## API modification Workflow

The following flow describes how to do any change in the API layer.

1)Apply the change to api-spec.yaml  
2)Generate the API interface via the command described in 'Generating interface from specification'  
3)Copy generated interface code into the files located in src/your-project-name/ControllersInterface  
4)Copy generated models code into the files located in src/your-project-name/Models  
5)Provide implementation for the defined interfaces in the corresponding files in ControllersImplementation.

## Generating API interface from specification

```bash
openapi-generator generate -i api-spec.yaml -g aspnetcore --additional-properties=packageName=NetCore.ApiFirst.OpenApi.Generator.WebApi,sourceFolder=autogen
```

The generated code is in the folder autogen, the important bits are the generated classes inside the Controllers folder which must be updated to Abstract classes

## Compare Spec file to actual controller to check if API Spec is updated

During build in CI/CD it is possible to generate the API interface from specification and use tools like bash [cmp](https://en.wikipedia.org/wiki/Cmp_(Unix)) to compare to the actual api interface

```bash
cmp --silent
src/NetCore.ApiFirst.OpenApi.Generator.WebApi/ControllersInterface/PetsApiController
autogen/Controllers/DefaultApi.cs
```