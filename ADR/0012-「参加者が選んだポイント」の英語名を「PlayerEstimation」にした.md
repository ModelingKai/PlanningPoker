# 12. 「参加者が選んだポイント」を「参加者の見積もり」とした


- [0011](./0011-「参加者が選んだポイント」の英語名を「PlayerPoint」にした.md)

## コンテキスト（Context）

- 1/13 の議論後、ふりかえり中に「PlayerPointか、PlayerEstimationかも含めて相談。PlayerEstimationにする場合、ADR 0012 を作り、0011 は廃止する。」という意見があった
- 参加者がポイントを選ぶ行為は、見積もりをしたという事ではないか。という議論があった


## 決定（Decision）

- 参加者が選んだポイントは、参加者の見積もりとした
- PlayerPoint は、 PlayerEstimate とした

## 結果 / 影響（Consequences）

- Miro上のモデルや用語を変更
- PlayerPointとコード上に表れたものをPlayerEstimationにリネーム
- ビジネスルールで利用しているポイントという単語は、見積もりに置き換えなかった。今後違和感があれば見直す。
