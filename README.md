# Entity Framework Core デモ
Entity Framework Coreをさくっと試してみるためのリポジトリです。  
実装例ごとにタグが打ってあります。

| 実装例                                | タグ | 
| :---                                 | :---: |
| 1. プロジェクトを作る                   | [step1](https://github.com/t-fujisaka-d1g/demo-entity-framework-core/tree/step1) |
| 2. テーブル作って、登録・更新・削除してみる | [step2](https://github.com/t-fujisaka-d1g/demo-entity-framework-core/tree/step2) |
| 3. テーブルを拡張してみる                | [step3](https://github.com/t-fujisaka-d1g/demo-entity-framework-core/tree/step3) |
| 4. リレーションシップを作ってみる         | [step4](https://github.com/t-fujisaka-d1g/demo-entity-framework-core/tree/step4) |
| 5. カラムの名称や型をカスタマイズする      | [step5](https://github.com/t-fujisaka-d1g/demo-entity-framework-core/tree/step5) |


## 実行方法
※ powershell, docker、dotnetが必要です。
1. リポジトリをクローンする
2. Entity Framework Coreツールをインストール
```
dotnet tool install --global dotnet-ef
```
3. SQLServerを起動する(in Dockerコンテナ)
```
./start-docker-mssql.ps1
```
4. データベースを作成
```
 dotnet ef database update
```
5. 実行
```
dotnet run
```

## ER図
![キャプチャ](https://github.com/t-fujisaka-d1g/demo-entity-framework-core/blob/main/er.png)
