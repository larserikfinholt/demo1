Software
- WSL (Windows 10 insider)
- Docket Desktop (velg wsl experimental)

Mål
- [x] docker i wsl
- [ ] docker compose frontend og to servicer
- [ ] mongodb
- [ ] gRPC
- [ ] kubernetes
- [ ] dapr

Dette har jeg lært
- pwd (print working dir)
- code . (installerer code server, kjører remote)
- explorer.exe . (åpner explorer i \\wsl$\Ubuntu\home\lef\projects\demo1)
- wsl -l -v (list distros og wsl version)
- docker ps (list containers)
- | grep jalla (filter on jalla)
- docker images (list images)
- dotnet run / build / version
- vs code workspaces / docker plugin / add dockerfiles to workspace...
- git config --global user.name "jalla" (og user.email)
- K8 videoserie https://www.youtube.com/playlist?list=PLLasX02E8BPCrIhFrc_ZiINhbRkYMKdPT 
- Dockerfile (flere steg)
- Docker intro: https://docs.microsoft.com/en-us/dotnet/core/docker/build-container
- docker build -t jalla . (bygg i dette dir og tagg med jalla)
- docker run jalla
- docker tag jalla larserikfinholt/jalla 
- docker push larserikfinholt/jalla
- docker images rm jalla
- docker run -it (interactive) -rm (remove) jalla (slett container etter process exit)
- vs workspace 
- docker-compse up / down
- homebrew (brew)
- .profile for å endre $PATH
- lazydocker 
- docker-compose down (det holder ikke å restarte container etter ny build)
- docker run -it -d -v /home/lef/data:/data/db mongo --name mongodb (kjør mongo interaktivt som deamon, db ligger lokalt)
- docker run –it mongo --name mongoclient /bin/bash (start med terminal)
- docker inspect mongodb (vis config)
- docker inspect -f '{{range .NetworkSettings.Networks}}{{.IPAddress}}{{end}}' mongodb (vis ipadresse)
- mongo 172.17.0.2:27017 (koble til, ipadresse finnes )
- mongo initere db ved å kjøre script på /docker-entrypoint-initdb.d (docker-compose)
- referer til image name ved nettverkskall mellom containere når compose