

## Contributors

## Design-choices
Front-End:
 - Frond-end framework:  React
 - Authentication: KeyCloak docker image
 - Folder-structure: type --> feature, AKA /src/components/feature, /src/services/feature, /src/pages/feature
 - CSS: React Bootstrap
 - State-Management-System: Redux
 - Project Creation: fra forelesning, npx create react app-case
 - Website deployment: Heroku
 - IDE: Visual studio code
 - Containerization: Docker
 - Package manager: Node.js and npm
 - Interface Design: Figma


Back-End:
 - Database: Microsoft SQL / SQL server
 - ORM: Entity Framework
 - Mapper: AutoMapper
 - Authentication: KeyCloak docker image
 - API deployment: Azure web app
 - API-Documentation: Swagger
 - API-Testing: Postman
 - IDE: Visual studio community edition

## Style-guide
.Net https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/coding-conventions
### Casing
 - .Net : 
    - Pascal-Case:
      - Class, record or struct, 
      - Interfaces are prepended I like IWorkerQueue
      - public members of types, such as fields, properties, events, methods, and local functions
    - camel-Case
      - private or internal fields prefix with _, use camelcasing _workerQueue
 - React : 
     - Pascal-Case:
       - Components
       - 
     - kebab-case
       - html/xml tags inside components
       - css

### Layout
 - .Net: 
    - Indent four-characters, tabs saved as spaces


### Git
https://www.conventionalcommits.org/en/v1.0.0/
 - commit-message:
   - feat: new feature, code added
   - fix: bugfix usually
   - style: no functional changes
   - docs: documentation
