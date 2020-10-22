#!/usr/bin/env bash
set -e

exitCode=-1
docker system prune -f

dotnet publish ./MembershipApi/MembershipApi.csproj -c Release

docker-compose -f ./docker-compose-local.yml up --build --exit-code-from test

exitCode=$?

docker-compose -f ./docker-compose-local.yml down --remove-orphans

RED="\033[1;31m"
GREEN="\033[1;32m"

if [ $exitCode -eq 0 ]
then
   echo -e "${GREEN}Tests PASSED. "
   
else
    echo -e "${RED}Tests Failed. "
fi

exit $exitCode