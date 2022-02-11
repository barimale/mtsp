# Scenario
- [STEP A] Provide list of postpersons,
- [STEP B] Provide main spot together with places which have to be visited (raw json only),
- [STEP C] Provide some assumptions like: maximal limit of hours per route - optional,
- [STEP D] Display them on map as a form of review,
- [STEP D -> STEP E] Send data to backend to calculate subroutes per postperson,
- [STEP E] Display result on map.
- [STEP F] Send result via email - optional

# Mini-server configuration
```
Public IP: 94.132.173.156
Local IP: 192.168.2.100

username: albergue
password: albergue 
```

```
scp -r ./bin/Release/net5.0/publish/* albergue@192.168.2.100:/var/www/albergue.administrator

sudo cp ./Properties/albergue-administrator.service /etc/systemd/system/albergue-administrator.service
sudo systemctl daemon-reload
cd /etc/systemd/system
sudo systemctl enable albergue-administrator.service
sudo sudo journalctl -fu albergue-administrator.service

```

https://localhost:5021;

# Format and lint
```
dotnet tool install -g dotnet-format
```
Usage:
```
dotnet-format .\Multiple-Salesman-Problem-API.sln
```

# TypeGen
Install:
```
dotnet tool install --global dotnet-typegen
```
Rebuild the solution and then by being in the root directory execute:
```
dotnet-typegen --project-folder  ./Christmas.Secret.Gifter.Domain generate
```
# Frontend Extensions - VS Code
## Generate barrels
```
TypeScript Barrel Generator
```
## ESLint & Prettier - VS Code
```
npm install -D eslint prettier eslint-config-prettier
npx eslint --init
```

# Database.SQLite:
navigate to the database project directory first.
Then execute as follows:
```
dotnet tool install --global dotnet-ef
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet ef migrations add InitialCreate
dotnet ef database update

dotnet ef database update --connection "Data Source=gifter.db"
```

# Known issues
Nuget: invalid data while decoding:
```
dotnet nuget locals all --clear
```

# Algorithm
```
https://developers.google.com/optimization/assignment/assignment_example
```

# Heroku deployment
## Prereqs
```
choco install heroku-cli
heroku login
heroku container:login
heroku create
heroku stack:set container
```
As a result the app in Heroku is created.
## Startup
Each time, you want to deploy the app to Heroku:
```
heroku login
heroku container:login
heroku git:remote -a lit-spire-23553
heroku stack:set container
git push heroku main
```
or:
```
heroku login
heroku container:login
heroku container:push web -a lit-spire-23553
heroku container:release web -a lit-spire-23553
```
In case of any error:
```
heroku logs --tail
```