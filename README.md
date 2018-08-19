# BizLogicSample
rebuild bizlogic

## Target
UWPのx:Bindを基本にVMとBizLogicを考え直す。
クライアントUIアプリケーションの場合では、サーバ契機のイベントはPush以外発生しない。
よってawaitのみでUIスレッド処理すればよくなるので従来のRunOnUIThreadは不要となる。
画面遷移をVMプロパティのみで実装できれば完全分離が可能のはず。

## CheckPoint
AndroidでBizLogicをどこに置くか、永続化をどうするか。
Applicationライフサイクルをもう一度確認する。

### Android application
アプリケーションの生成はonCreateでフックできる。
しかしアプリケーションの終了イベントが無い。
ApplicationにBizLogicを置いてもコミット契機以外での保存タイミングが無い。

### Advantage of BizLogic on Application
アプリケーションのライフサイクルはActivityライフサイクルとは無関係であり、
開発者向けオプションのアクティビティを保持しないをONにした場合に違いが表れる。

#### BizLogic on Activity
ユーザ入力契機ではないActivityの消滅時にBizLogicも消滅してしまう。
よってActivityライフサイクルの終わりにBizLogicを保存しないと、
バックグラウンドフォアグラウンドで入力内容が消えてしまう。

#### BizLogic on Application
ユーザ入力契機ではないActivityの消滅時でもアプリケーションが生きている。
このためBizLogicはオンメモリで保持されていて、
Activityのリサイクル時にも入力内容が復元される。

### Disadvantage of BizLogic on Application
しぶとく生き続けるアプリケーションもメモリ不足の際には勝手に消去されてしまう。
この消えるイベントが無いため、この場合ではBizLogicは保存されず最終保存時点に
戻されてしまうことになる。
メモリ不足イベントはあるのでここで保存することは可能。
