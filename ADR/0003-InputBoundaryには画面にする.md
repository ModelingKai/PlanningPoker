# 3.InputBoundaryには画面にする
## コンテキスト（Context）

ロバストネス分析図のインプットバウンダリに画面を当てるか、画面の中の要素（インターフェース、コンポーネントなど）を当てるかの議論となった。

ロバストネス分析の段階で画面として話すと、必要以上に詳細な話に入ってしまうことを懸念した。
  
ただし、ユースケース駆動開発の本を読むとインプットバウンダリは「〇〇ページ」としており、ユースケース記述の際にモックアップなどを作ることになっていた。


## 決定（Decision）
- 画面を対象にすることにした
- 命名規則は「○○画面」とする


## ステータス（Status）
承認済

## 結果 / 影響（Consequences）

- ロバストネス分析の図には、「●●画面」という名前でバウンダリーオブジェクトが作られる
- 「○○インターフェース」というバウンダリオブジェクトは、ロバストネス分析に利用する仮の画面設計にのみ登場する（コンポーネント的な位置づけ）