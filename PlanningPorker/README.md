# Applicationの実行

## Requird
- dotnet cli
- [DataStore(EventStoreDB)](#DataStoreの環境立ち上げ)

## 実行
```shell
cd ConsoleApp && dotnet run
```
# DataStoreの環境立ち上げ

## Required
- Docker

## セットアップ

### 実行
```shell
docker run --name esdb-node -it -p 2113:2113 -p 1113:1113 eventstore/eventstore:23.10.0-bookworm-slim --insecure --run-projections=All --enable-atom-pub-over-http
```

- 参考：[Download EventStoreDB 23\.10 LTS: An Open\-Source Database for Event Sourcing \| Event Store](https://www.eventstore.com/downloads/23.10)


### 確認
- http://localhost:2113 アクセス
    - 以下のようなdashboardが出ればOK

![image](https://github.com/ModelingKai/PlanningPoker/assets/33717710/34167770-cb82-4da6-a0a5-22882d98b411)


