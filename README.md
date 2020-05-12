## ◆環境
①Windows10

②Visual Studio 2019

## ◆アプリ概要
リクエスト内容により、付箋メモのデータを登録・変更・削除するAPIを作成する。

又、複数ユーザの平行利用を想定し、編集中のユーザ以外は閲覧のみ可能とし、どのユーザが編集しているかもAPIで管理する。

現状は、APIの疎通確認が行える。

又、DBを使用していないが、編集中のユーザでない限り、メモデータの更新は行えない処理を追加している。

## ◆起動コマンド

Visual Studioにて、Ctrl + F5キーでアプリを実行できる。

※デバッグモードでの起動でも可能。

## ◆確認方法

Google Chromeの拡張機能であるTalend API Testerを使用している。

リクエストの内容は以下の構成とする。

#### ◆編集開始API
```bash
【POST】http://localhost:9999/edit/start/{userId}
userId：文字列
```

Bodyデータ：なし

#### ◆データ追加API
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

#### ◆データ削除API
```bash
【DELETE】http://localhost:9999/edit/remove/{userId}/{memoId}
userId：文字列
memoId：数値
```

#### ◆編集終了API
```bash
【DELETE】http://localhost:9999/edit/end/{userId}
userId：文字列
```

#### ◆データ取得API
```bash
【GET】http://localhost:9999/get/data
```

