
# 10. EventStoreDB に入出力する DomainEvent をSerializableにする

## コンテキスト（Context）

- 「参加者がポイントを決定した」等イベントのプログラム中での取り扱い方について議論した。
    - そもそもDomainEvent自体をSerializableにするか
    - もしくはSerializableなオブジェクトをまた別に用意するか（DTO）

## 決定（Decision）

- PlaningPokerCoreの下にDomain/Eventとフォルダを切る
- その配下につくったDomainEvent自体をSerializableにする


## 結果 / 影響（Consequences）

- Event以外のDomaiオブジェクトはDomain/Entityのフォルダ配下置く
    - 違和感があれば修正する

- EventStoreDB に入出力する型の中身をどうするか検討する必要がある。
    - 1. string などの primitive しか使わない方法
    - 2. 独自に定義した型を使う方法

