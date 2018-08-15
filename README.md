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
