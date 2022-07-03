# PKContainer

dotnet ef database update -p .\Services\KPService\KP.Infrastructure -s .\Services\KPService\KP.API
dotnet ef migrations add InitialCreate -p .\Services\KPService\KP.Infrastructure -s .\Services\KPService\KP.API

[System.Environment]::SetEnvironmentVariable('ResourceGroup','AZ_Resource_Group')

can use this to simplify the context factory for connectionstring


## create db role
Create Role kpi_app AUTHORIZATION db_securityadmin
create login app with password='djfie9$dji'
create user app for login app
ALTER ROLE kpi_app ADD MEMBER app

Grant Alert on Show to kpi_app

ALTER ROLE db_datareader ADD MEMBER globoticket_app


dotnet tool install dotnet-user-secrets --global 
dotnet user-secrets init -p .\KP.API
dotnet user-secrets set "ConnectionStrings:KpConnection = Data Source=localhost;Initial Catalog=KPI2;Integrated Security=SSPI;Persist Security Info=True;MultipleActiveResultSets=True;"

Secure Storage:

	Azure Key Vault
	AWS Key Manager

	Kubernetes Key managers
		Hashicorp vault

	Enviroment variables
		ConnectionStrings__KpConnection


dotnet ef migrations bundle
	-p .\KP.Infrastructure\ 
	-s .\KP.API\
	--self-contained
	--target-runtime linux-x64


	efbundle --connection "admin connection string"

need make sure it is in the same directory need access appsettings.json, then execute ./dfbundle --connection "admin connection string" 

run docker images

	docker build 
		-t kp/integration-test:latest (-t means give a name)
		-f integrationtest/integrationtest.dockerfile (-f means file location)
	.

	docker run
		-it --rm       (if want to run the container interactively so that you can see what is going on and enter commans, use -it flags; delete container after it is done, use --rm flag)
		--entrypont /bin/bash
		kp/integration-test:latest