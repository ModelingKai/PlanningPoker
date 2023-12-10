# 9. イベント駆動アーキテクチャのリードモデルで、EventStoreDBのLiveProjectionを採用する

## コンテキスト（Context）

- 主な方式として
    - EventStore と ReadModelStore を分けて Read/Write を分離する方式
    - EventStore 単体で Read/Write の両方を賄う LiveProjection 方式

## 決定（Decision）

- イベント駆動アーキテクチャのデータストアで LiveProjection を採用する
    - 参考: https://www.eventstore.com/blog/live-projections-for-read-models-with-event-sourcing-and-cqrs
- 別でDBを立てるのはコストが掛かると判断
- EventStoreDBの機能をちゃんと使ってみるという理由もある

## 結果 / 影響（Consequences）

- 将来的に ReadModelStore が欲しくなる可能性がある（が、現時点ではまだ手を付けない）

