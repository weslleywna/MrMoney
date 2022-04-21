# MrMoney

DOCKER RUN com as portas http e https liberadas mais o certificado gerado 


dotnet dev-certs https -ep $env:USERPROFILE\.aspnet\https\aspnetapp.pfx -p { password here }
dotnet dev-certs https --trust


docker run --rm -it --name container --sig-proxy=false -p 8000:80 -p 8001:443 -e "ASPNETCORE_URLS=https://+;http://+" -e "ASPNETCORE_ENVIRONMENT=Development" -e "ASPNETCORE_HTTPS_PORT=8001" -e "ASPNETCORE_Kestrel__Certificates__Default__Password={ password here }" -e "ASPNETCORE_Kestrel__Certificates__Default__Path=/https/aspnetapp.pfx" -v $env:USERPROFILE\.aspnet\https:/https/ teste:latest
