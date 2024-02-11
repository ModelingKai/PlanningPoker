# 13. Domainフォルダ以下はドメインの用語に合わせたフォルダ構成にする

## コンテキスト（Context）

- フォルダ構成を Domain/Entity としていたが、技術的な興味に寄ってしまっているという指摘があった。


## 決定（Decision）

- ドメインの言葉を使ったフォルダ構成(Name space) とし、Entity, Domain Object/Primitve, Event, UseCase を配置する。
 - 例: 
   - PlanningPorkerCore/Domain/Players/PlayerId.cs
   - PlanningPorkerCore/Domain/Players/EstimatedByPlayerEvent.cs
 


## 結果 / 影響（Consequences）

- [0010](./0010-EventStoreDBに入出力するDomainEventをSerializableにする.md)の決定でフォルダ構成に影響があったが、こちらの方に対応する
