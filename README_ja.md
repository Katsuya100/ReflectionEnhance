# ReflectionEnhance
## 概要
本ライブラリ「ReflectionEnhance」は高速なReflectionを提供します。  
.Net標準の`System.Reflection`よりも高速に実行できます。  

## 動作確認環境
|  環境  |  バージョン  |
| ---- | ---- |
| Unity | 2021.3.38f1, 2022.3.20f1 |
| .Net | 4.x, Standard 2.1 |

## 性能
### エディタ上の計測コード
[Assembly系テストコード](packages/Tests/Runtime/REAssembly/AssemblyPerformanceTest.cs)  
[Type系テストコード](packages/Tests/Runtime/REType/TypePerformanceTest.cs)  
[ConstructorInfo系テストコード](packages/Tests/Runtime/REConstructorInfo/ConstructorInfoPerformanceTest.cs)  
[FieldInfo系テストコード](packages/Tests/Runtime/REFieldInfo/FieldInfoPerformanceTest.cs)  
[MethodBase系テストコード](packages/Tests/Runtime/REMethodBase/MethodBasePerformanceTest.cs)  
[Enum系テストコード](packages/Tests/Runtime/REEnum/EnumPerformanceTest.cs) 

※ビルド後も同様の計測コードを使用しています。

#### 結果
以下は抜粋です。

|  実行処理  |  Mono(Develop)  |  Mono(Release)  |  IL2CPP(Develop)  |  IL2CPP(Release)  |
| ---- | ---- | ---- | ---- |
| Type.GetField(Legacy) | 3.80069 sec | 3.789642 sec | 6.671875 sec | 6.617188 sec | 
| Type.GetFieldFast | 0.009490967 sec | 0.009613037 sec | 0.0078125 sec | 0.0078125 sec | 
| Type.FieldOf | 0.5515747 sec | 0.5567932 sec | 0.171875 sec | 0.1640625 sec |
| FieldInfo.GetValue(Legacy) | 1.1716 sec | 1.239502 sec | 0.6152344 sec | 0.5097656 sec | 
| FieldInfo.GetStaticValueFast | 0.2137909 sec | 0.2355499 sec | 0.3222656 sec | 0.2871094 sec | 
| StaticFieldPointer.GetValue | 0.01437378 sec | 0.01635742 sec | 0.015625 sec | 0.01171875 sec | 
| MethodBase.Invoke(Legacy) | 3.869812 sec | 4.164734 sec | 1.865234 sec | 1.8125 sec | 
| MethodBase.InvokeStaticFast | 0.240387 sec | 0.2815857 sec | 0.296875 sec | 0.3085938 sec | 
| StaticMethodPointerFunc.Invoke | 0.04116821 sec | 0.05160522 sec | 0.04296875 sec | 0.03125 sec | 
| Delegate | 0.0333252 sec | 0.04013062 sec | 0.03125 sec | 0.0234375 sec | 

[詳細な計測結果](measure.csv)  

`GetField`は条件が整えばほぼ処理時間がなくなります。  
他の`GetMember`系メソッドも同様です。  
FieldOfを使うとGetFieldFastほどでありませんが高速化されます。  
（またキャッシュを作らないので省メモリです。）  
GetValueは5倍程度、Invokeは16倍程度に処理性能が向上しています。  
また、`FieldInfo`型を`FieldPointer`型に変換すれば81倍に向上。  
`MethodBase`型を`MethodPointer`型に変換すれば94倍程度に性能向上します。  
(`Delegate`型はさらに高速ですが、インスタンスメソッドであれば`MethodPointer`型にしておくことでターゲットを変更できるメリットがあります。)  

## インストール方法
### 依存パッケージをインストール
以下のパッケージをインストールする。  

- [BoxingPool v1.3.1](https://github.com/Katsuya100/BoxingPool/tree/ver1.3.1)
- [ILPpostProcessorCommon v2.3.0](https://github.com/Katsuya100/ILPostProcessorCommon/tree/ver2.3.0)
- [MemoizationForUnity v1.5.0](https://github.com/Katsuya100/MemoizationForUnity/tree/ver1.5.0)
- [GenericEnhance v1.1.0](https://github.com/Katsuya100/GenericEnhance/tree/ver1.1.0)
- [ConstExpressionForUnity v3.2.0](https://github.com/Katsuya100/ConstExpressionForUnity/tree/ver3.2.0)

### ReflectionEnhanceのインストール
1. [Window > Package Manager]を開く。
2. [+ > Add package from git url...]をクリックする。
3. `https://github.com/Katsuya100/ReflectionEnhance.git?path=packages`と入力し[Add]をクリックする。

#### うまくいかない場合
上記方法は、gitがインストールされていない環境ではうまく動作しない場合があります。
[Releases](https://github.com/Katsuya100/ReflectionEnhance/releases)から該当のバージョンの`com.katuusagi.arraypool.tgz`をダウンロードし
[Package Manager > + > Add package from tarball...]を使ってインストールしてください。

#### それでもうまくいかない場合
[Releases](https://github.com/Katsuya100/ReflectionEnhance/releases)から該当のバージョンの`Katuusagi.ReflectionEnhance.unitypackage`をダウンロードし
[Assets > Import Package > Custom Package]からプロジェクトにインポートしてください。

## 使い方
### 互換メソッド
以下のように多くのメンバにFastをサフィックスに持つ互換メソッドが用意されています。
```.cs
//  field = typeof(Vector3).GetField("x");
var field = typeof(Vector3).GetFieldFast("x");
```

以下のように条件追加された互換メソッドも用意されています。
```.cs
//  x = field.GetValue(vec);
var x = field.GetInstanceValueFast<Vector3, float>(ref vec);
```
特に`GetValue`メソッドや`Invoke`メソッド等は最適化のためにジェネリック引数で型を指定できるようになっています。

### FieldPointer/MethodPointer型
以下のように`FieldInfo`型から`FieldPointer`へ暗黙的変換を行うことができます。  
```.cs
InstanceFieldPointer<Vector3, float> field = typeof(Vector3).GetFieldFast("x");
var x = field.GetValue(ref vec);
```

`FieldPointer`型は`FieldInfo`型の互換メソッドよりもさらに高速にアクセスできます。  
また、`MethodPointer`型も用意しています。  
Delegateと違い、Invoke時にターゲットを指定できます。  
```.cs
InstanceMethodPointerAction<Vector3, float, float, float> method = typeof(Vector3).GetMethodFast<float, float, float>("Set")
method.Invoke(ref vec, 1, 2, 3);
```

### Substitution型
`GetMethodFast`などのジェネリック引数でByRef型などを指定できるよう`Substitution`型を用意しています。  
以下の記法でByRef型をジェネリック引数で指定できます。
```.cs
var method = typeof(Dictionary<string, int>).GetMethodFast<string, ByRefLike<int>>("TryGetValue");
int result = 0;
method.InstanceInvoke<string, ByRefLike<int>, bool>("hoge", ByRefLike.As(result));
```

サポートしている`Substitution`型は以下です。

|  型名  |  意味  |
| ---- | ---- |
|  ByRefLike\<T\> | ref T |
|  PointerLike\<T\> | T\* |
|  VoidLike | void |
|  GenericTypeParameterLike\<_N\> | N番目のジェネリック型の型引数 |
|  GenericMethodParameterLike\<_N\> | N番目のジェネリックメソッドの型引数 |

### FieldOf/MethodOf
高速にメンバを取得できる演算子を用意しています。  
見た目はメソッドですが、内部的な挙動は`typeof`に非常に近いです。  
```.cs
var field = typeof(Vector3).FieldOf("x");
var method = typeof(Vector3).MethodOf<float, float, float, VoidLike>("Set");
```
存在しないメンバを指定した場合はコンパイルエラーになります。  
また、ハンドルから直接取得しているため省メモリです。  

### 便利メソッド
本来のリフレクションには存在しない便利なメソッドを多く用意しています。  
以下は一例です。  

|  型  |  メソッド  |  意味  |
| ---- | ---- | ---- |
| REReflection | GetUsingGenericInstanceTypes | 使用中のGenericInstance型の一覧を取得する |
| REReflection | GetUsingArrayTypes | 使用中の配列型の一覧を取得する |
| REReflection | GetUsingByRefTypes | 使用中のByRef型の一覧を取得する |
| REReflection | GetUsingPointerTypes | 使用中のPointer型の一覧を取得する |
| REAssembly | IsReferenceTo | 参照しているアセンブリを判定する |
| REAssembly | IsReferenceFromo | 参照されているアセンブリを判定する |
| Type | GetTypeWithMoved | MovedFromを考慮した型取得を行う |
| Type | GetSerializeFields | SerializeField一覧を取得する |
| Type | IsArrayOfUnitySerialize | UnityのSerialize時に配列として認識される型を判定する |
| FieldInfo | IsSerializeField | SerializeFieldかどうかを判定する |
| MethodBase | IsOverridable | 仮想メソッドかどうかを判定する |
| MethodInfo | IsOperator | オペレーターオーバーロードメソッドかどうかを判定する |
| MethodInfo | IsCompatible | メソッドの互換性を判定する |

### Tips
#### 高速化テクニック
引数はすべて定数であったほうが高速に動作します。
```.cs
// 遅い実装
t.GetFieldFast(memberName);

// 早い実装
typeof(Vector3).GetFieldFast("x");
```

また、typeofはローカルキャッシュしないほうが高速になります。
```.cs
// 遅い実装
var t = typeof(Vector3);
t.GetFieldFast(memberName);

// 早い実装
typeof(Vector3).GetFieldFast(memberName);
```

#### エラーチェック
`GetMember`系メソッドは引数がすべて定数である場合にコンパイル時存在チェックを行います。
```.cs
// これはコンパイルエラーになる。
typeof(Vector3).GetFieldFast("w");
```

## 高速な理由
`ReflectionEnhance`による`GetMember`系関数は`StaticExpression`、`コンパイル時最適化`、`Memozation`の3段階で最適化しています。  
まず、以下のようにすべての引数がコンパイル時解決可能な場合、`StaticExpression`によってコンパイル時にリプレース最適化の対象になります。  
```.cs
var field = typeof(Vector3).GetFieldFast("x");
// -> var field = $$StaticTable_0.result;
```

コンパイル時解決ができない場合でも動的に`Memoization`によって最適化されています。  

つぎに型をコンパイル時解決できる場合はGeneric引数を使った関数に置き換えられます。  
```.cs
var field = typeof(Vector3).GetFieldFast(name);
// -> var field = REReflection.GetFieldFast<Vector3>(name);
```
`Memoization`は引数が少ないほど高速に動作しますので、この最適化によって高速化されます。  

次に`FieldInfo.GetValue`系関数も特殊な最適化を行っています。  
Instance fieldの場合はオフセットアドレスを用いたアクセスを行って高速にフィールドを取得します。  
Static fieldの場合は変数のアドレスを取得して直接操作しています。  
高速に処理できる上、object型を経由しないためBoxingを回避できます。   
  
`MethodBase.Invoke`系関数はネイティブの関数ポインタを用いて処理しています。  
こちらも直接呼び出せるのに加えてBoxingを回避できます。  

これらのテクニックにより、Reflectionを高速化させることに成功しています。  