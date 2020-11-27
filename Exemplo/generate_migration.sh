#!/bin/bash
set -e


if [ $# -lt 1 ]; then
   echo "Faltou informar o branch do checkout"
   exit 1
fi

MIGRATIO_NAME=$1


dotnet ef migrations add $MIGRATIO_NAME -c AuthDataContext -o Data/Migrations/Auth
dotnet ef migrations add $MIGRATIO_NAME -c StoreDataContext -o Data/Migrations/Store
