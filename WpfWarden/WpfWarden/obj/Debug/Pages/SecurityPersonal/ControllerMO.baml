   M S B A M L   `   `   `  ����D  @WpfWarden, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS.clr-namespace:WpfWarden.Pages.SecurityPersonal WpfWarden.Pages.SecurityPersonal  5      3    -WpfWarden.Pages.SecurityPersonal.ControllerMO   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      @local.clr-namespace:WpfWarden.Pages.SecurityPersonal     5      -   5          N� Title$  ControllerMO��5	      .��5      �  � RowDefinitions 5   
   �� 5      6   .+�5   
   �� -   5         ��Name$ txtFIO��5      $��Right=�6$   $	��Top=�6@   $��0 2 5 5q�6X   $��20(�6i   6y   �� 5   
   .@�5      �� $��Логи��6   $��16(�6$    � 	Resources 5       �� 
TargetType �� Property �� Value��%k   '��       �� 5      " ��6   .�5      ��  �@��CornerRadius$ 	10 10 0 0��69   6M   5      5      ��5      � 5       5      �� 5      $��80 �6,   6:   �� 5      6.   �� 5      $��40 �6,   6:   .+�5      �  5      �� 5    "   62   �� 5!   "   62   .+�5#      ��  �� Orientation$ 
Horizontal=�6)   $��Center=�6B   $��0��6_   $��Center=�6l   .+�5$   "   �� $'��!Код пользователя: ��6,   $��18(�6F   6V   �� 5%   "   -   5         ��Name$ 	txbUserId��5%   *   $��60��6a   6n   �� 5&   "   -   5        	 ��Name$	 cmbLogLevels��5&   9   $
��20 0q�6+   
 �� DisplayMemberPath$
 LogLevel��6O   6�   �� 5'   "   -   5         ��Name$ 
ckbShowOld��5'   +   $#��Показать старые��6{   6�   5(      �� 5)      $ 
Horizontal=�6)   $��Center=�6B   $��1��6_   $��Center=�6l   .+�5*   "   �� $'��!Поиск в сообщении:��6,   $��18(�6F   6V   �� 5+   "   -   5        $ txbSearchInMessage��5+   *   $	��350��6s   6�   5,      5-      &   System.Windows.Controls.DataGrid  5.      -   5          Name$ DGLogs��5.   �   $��1��6#      AutoGenerateColumns .     
IsReadOnly .    CanUserAddRows .     CanUserDeleteRows .     Columns 5/      0  *System.Windows.Controls.DataGridTextColumn  50   "   ,  &System.Windows.Controls.DataGridColumn   Header$ Платформа��65   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6H   �� *MachineName+6j     51   "   $ Уровень��65    6F   �� *
LogLevel+6e     52   "   $ Дата��65    6C   �� *Logged+ �� StringFormat$ {0:dd.MM.yy}��6}     53   "   $ 
Время��65    6D   �� *Logged+$ {0:HH:mm:ss}��6~     54   "   $ Сообщение��65    6H   �� *	Message+6f     55   "   $ Ошибка��65    6E   �� *	Exception+6e   4  .System.Windows.Controls.DataGridTemplateColumn  56   "   $ Пользователь��69      CellTemplate 57   &   �� 58   *   .R�59   .   ��  �� 
IsReadOnly .  �� 
IsEditable .   J� IsManipulationEnabled .  .@�5:   2   �� $
��Left=�6?   ��5;   6   �� 5<   :   $ 
Horizontal=�6E   $
��Left=�6^   $��Center=�6y   .+�5=   >   �� $��18(�6H   ��6V   �� *Users.UserId+$ Код: {0}��6�   5>   ;   5@   3   �� 5A   2   $
��Left=�6?   ��6a   �� *Users.SecondName+6�   �� 5B   2   $
��Left=�6?   ��6a   �� *Users.FirstName+6�   �� 5C   2   $
��Left=�6?   ��6a   �� *Users.ThirdName+6�   �� 5D   2   $
��Left=�6?    �� 
IsSelected . ��6s   �� *Users.Permission.Name+6�   �� 5E   2   $��Center=�6;   $$��Верифицирован(а)��6�    d� 	IsChecked 6_   �� *Users.IsVerify+6�   5F   /   5G   +   5I   #   5K      �� 5L      $��2��6%   $ 
Horizontal=�62   $��Center=�6K   $��Center=�6h   .+�5M      �� -   5         ��Name$ btnPageMinus��5M   A   $��
Назад��6%   $	��100��65   6t   �� 5N      -	   5        $ 
txbPageNow��5N   (   $
��20 0q�6<   $��20(�6J   6Z   �� 5O      -
   5        $ btnPagePlus��5O   A   $��
Далее��6%   $	��100��65   6r   5P      5Q      5S      �� 5T      $��Пользователи��6   $��16(�6,    5U      ��%k   '��       �� 5V      " ��6   .�5W      ��  �@��CornerRadius$ 	10 10 0 0��69   6M   5X      5Y      ��5Z      � 5[       5\      �� 5]      6.   �� 5^      $��40 �6,   6:   .+�5`        -   5        $ DGUsers��5`   �    .   .   .   .   5a        5b   "   $ Код��65      
IsReadOnly .  6B   �� *UserId+6]     5c   "   $ Фамилия��65    .  6F   �� *
SecondName+6e     5d   "   $ Имя��65    .  6B   �� *	FirstName+6`     5e   "   $ Отчество��65    .  6G   �� *	ThirdName+6e     5f   "   $ Должность��65    .  6H   �� *Division.Name+6j     5g   "   $% Тип пользователя��65    .  6O   �� *Permission.Name+6s     5h   "   $  Верифицирован��65    .  6L   �� *IsVerifyText+6�   4  .System.Windows.Controls.DataGridCheckBoxColumn  5i   "   $  Заблокировать��69    6P   �� *	IsBlocked+6p   5k      �� 5l      -   5        $ btnBlock��5l   F   $��1��6!   $ ��Заблокировать��6.   6q   5m      5o      5p      5q      5r      