   M S B A M L   `   `   `  ????I  ECryproExplorer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:CryproExplorer.MVVM.ViewModelCryproExplorer.MVVM.ViewModel  5   	   /clr-namespace:CryproExplorerCryproExplorer  5   	       CryproExplorer.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   A	viewModel+clr-namespace:CryproExplorer.MVVM.ViewModel     5   	   .localclr-namespace:CryproExplorer     5   	   $	??600??5	   	   $	??920??6     ? WindowStyle$
  None=?5
   	    ? 
ResizeMode$ NoResize=?5   	   
??????  ? AllowsTransparency$
 True??5   	    ? DataContext 5      1   +CryproExplorer.MVVM.ViewModel.MainViewModel  5   
   .??5      ?? ???#272537 ?? CornerRadius$ 20??6"   ._?5   
   ?  ? ColumnDefinitions 5      ?? 5      $	??200 ?6#   ?? 5       ? RowDefinitions 5      ?? 5      $??75 ?6    ?? 5      .+?5      ?? $??CryptoExplorer??6   $??Center=?5       $
??Left=?5!      
???????$??22(?5#      $??20, 0, 0, 0q?5$      ?? 5'      $??1??6   $??5q?6&   .+?5(      	? $
??Home??6   $??50??5)      
???????$??14(?5+         MenuButtonTheme#??[  5,       d? 	IsChecked$
 TrueY?5-      ??5.      ?? *HomeViewCommand+	? 50      $??Assets??6   $??50??51      
???????$??14(?53      #??[  54      ??55      ?? *AssetsViewCommand+	? 57      $??Convert??6   $??50??58      
???????$??14(?5:      #??[  5;      ??5<      ?? *ConverterViewCommand+5=      ?? 5?      $??1??6   $??1??5@      $??5q?5A      ??5B      ?? *CurrentView+5C      5D      5F      