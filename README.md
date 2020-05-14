## ◆環境
①Windows10

②Visual Studio 2019

③Docker

④docker-compose

## ◆アプリ概要
リクエスト内容により、付箋メモのデータを登録・変更・削除するAPIを作成する。

又、複数ユーザの平行利用を想定し、編集中のユーザ以外は閲覧のみ可能とし、どのユーザが編集しているかもAPIで管理する。

現状は、APIの疎通確認が行える。

又、DBを使用していないが、編集中のユーザでない限り、メモデータの更新は行えない処理を追加している。

## ◆起動コマンド
①Redis、MySQLをDockerコンテナで起動

### Dockerコマンドまとめ
#### [1]コンテナ一覧表示
> docker ps

#### [2]コンテナ作成・バッググラウンド起動
> docker-compose up -d

#### [3]コンテナ・イメージ・ボリューム・ネットワークを一括完全消去
> docker-compose down --rmi all --volumes

#### [4]コンテナ接続
> docker exec -it [NAMES] bash

NAMES：コンテナ一覧の表示で「NAMES」項目を追加

※Windoswの場合、上記コマンドの先頭に「winpty」を加えなければいけない可能性がある。

#### [5]コンテナ接続から切断
> exit

### Redisコマンドまとめ
#### [1]Redis接続
> redis-cli

#### [2]Redisに登録されているキーの一覧を確認
> keys *

#### [3]キーに登録されている値を確認
> get [key]

②APIをVisual Studioにて、実行できる。

※デバッグモードでの起動でも可能

## ◆確認方法
Google Chromeの拡張機能であるTalend API Testerを使用している。

リクエストの内容は以下の構成とする。

#### ①編集開始API
```bash
【POST】http://localhost:9999/edit/start/{userId}
userId：文字列
```

Bodyデータ：なし

#### ②データ追加API
```bash
【PUT】http://localhost:9999/edit/add/{userId}/{memoId}
userId：文字列
memoId：数値
```

Bodyデータは以下のようにする。

```bash
{
  "memoData":"メモ文字列"
}
```

#### ③データ削除API
```bash
【DELETE】http://localhost:9999/edit/remove/{userId}/{memoId}
userId：文字列
memoId：数値
```

#### ④編集終了API
```bash
【DELETE】http://localhost:9999/edit/end/{userId}
userId：文字列
```

#### ⑤データ取得API
```bash
【GET】http://localhost:9999/get/data
```

