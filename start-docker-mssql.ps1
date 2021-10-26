$IMAGE_NAME="mcr.microsoft.com/mssql/server"
$CONTAINER_NAME="mssql"
$LOCAL_PORT=1433
$SA_PASSWORD="Pass1234"

# Dockerコンテナを起動
docker container run `
    -e "ACCEPT_EULA=Y" `
    -e "SA_PASSWORD=${SA_PASSWORD}" `
    -e "MSSQL_LCID=1041" `
    -e "MSSQL_COLLATION=Japanese_CI_AS" `
    -p ${LOCAL_PORT}:1433 `
    --name ${CONTAINER_NAME} `
    -d ${IMAGE_NAME}

Write-Host "Dockerコンテナを起動しました" -ForegroundColor DarkGreen
Write-Host "(なにかキーを押すと、Dockerコンテナを終了します)" -ForegroundColor DarkGreen
Read-Host

Write-Host "Dockerコンテナを終了しています..." -ForegroundColor DarkYellow

# Dockerコンテナを停止
docker stop ${CONTAINER_NAME}

# Dockerコンテナを削除
docker rm -f ${CONTAINER_NAME}

Write-Host "Dockerコンテナを終了しました" -ForegroundColor DarkGreen