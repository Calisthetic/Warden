   M S B A M L   `   `   `  ����G  CWpfWardenAPI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullY1clr-namespace:WpfWardenAPI.Pages.SecurityPersonal#WpfWardenAPI.Pages.SecurityPersonal  5      6    0WpfWardenAPI.Pages.SecurityPersonal.ControllerMO   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Clocal1clr-namespace:WpfWardenAPI.Pages.SecurityPersonal     5      -   5          N� Title$  ControllerMO��5	      .��5      �  � RowDefinitions 5   
   �� 5      6   .+�5   
   �� -   5         ��Name$ txtFIO��5      $��Right=�6$   $	��Top=�6@   $��0 2 5 5q�6X   $��20(�6i   6y   �� 5   
   .@�5      �� $��Логи��6   $��16(�6$    � 	Resources 5       �� 
TargetType �� Property �� Value��%k   '��       �� 5      " ��6   .�5      ��  �@��CornerRadius$ 	10 10 0 0��69   6M   5      5      ��5      � 5       5      �� 5      $��80 �6,   6:   �� 5      6.   �� 5      $��40 �6,   6:   .+�5      �  5      �� 5    "   62   �� 5!   "   62   .+�5#      ��  �� Orientation$ 
Horizontal=�6)   $��Center=�6B   $��0��6_   $��Center=�6l   .+�5$   "   �� $'��!Код пользователя: ��6,   $��18(�6F   6V   �� 5%   "   -   5         ��Name$ 	txbUserId��5%   *   $��60��6a   6n   �� 5&   "   -   5        	 ��Name$	 cmbLogLevels��5&   9   $
��20 0q�6+   
 �� DisplayMemberPath$
 logLevel��6O   6�   �� 5'   "   -   5         ��Name$ 
ckbShowOld��5'   +   $��Center=�6?   $#��Показать старые��6�   6�   5(      �� 5)      $ 
Horizontal=�6)   $��Center=�6B   $��1��6_   $��Center=�6l   .+�5*   "   �� $'��!Поиск в сообщении:��6,   $��18(�6F   6V   �� 5+   "   -   5        $ txbSearchInMessage��5+   *   $	��350��6s   6�   5,      5-      &   System.Windows.Controls.DataGrid  5.      -   5          Name$ DGLogs��5.   �   $��1��6#      AutoGenerateColumns$ False��60      
IsReadOnly$
 True��6L      CanUserAddRows$ False��6^      CanUserDeleteRows$ False��6u      Columns 5/      0  *System.Windows.Controls.DataGridTextColumn  50   "   ,  &System.Windows.Controls.DataGridColumn   Header$ Платформа��65   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6H   �� *machineName+6j     51   "   $ Уровень��65    6F   �� *
logLevel+6e     52   "   $ Дата��65    6C   �� *logged+ �� StringFormat$ {0:dd.MM.yy}��6}     53   "   $ 
Время��65    6D   �� *logged+$ {0:HH:mm:ss}��6~     54   "   $ Сообщение��65    6H   �� *	message+6f     55   "   $ Ошибка��65    6E   �� *	exception+6e   4  .System.Windows.Controls.DataGridTemplateColumn  56   "   $ Пользователь��69      CellTemplate 57   &   �� 58   *   .R�59   .   ��  �� 
IsReadOnly$
 True��67    �� 
IsEditable$ False��6I    J� IsManipulationEnabled$ False��6\   .@�5:   2   �� $
��Left=�6?   ��5;   6   �� 5<   :   $ 
Horizontal=�6E   $
��Left=�6^   $��Center=�6y   .+�5=   >   �� $��18(�6H   ��6V   �� *user.userId+$ Код: {0}��6�   5>   ;   5@   3   �� 5A   2   $
��Left=�6?   ��6a   �� *user.secondName+6�   �� 5B   2   $
��Left=�6?   ��6a   �� *user.firstName+6�   �� 5C   2   $
��Left=�6?   ��6a   �� *user.thirdName+6�   �� 5D   2   $
��Left=�6?    �� 
IsSelected$
 True��6a   ��6s   �� *user.division.name+6�   5E   /   5F   +   5H   #   5J      �� 5K      $��2��6%   $ 
Horizontal=�62   $��Center=�6K   $��Center=�6h   .+�5L      �� -   5         ��Name$ btnPageMinus��5L   A   $��
Назад��6%   $	��100��65   6t   �� 5M      -	   5        $ 
txbPageNow��5M   (   $
��20 0q�6<   $��20(�6J   6Z   �� 5N      -
   5        $ btnPagePlus��5N   A   $��
Далее��6%   $	��100��65   6r   5O      5P      5R      �� 5S      $��Пользователи��6   $��16(�6,    5T      ��%k   '��       �� 5U      " ��6   .�5V      ��  �@��CornerRadius$ 	10 10 0 0��69   6M   5W      5X      ��5Y      � 5Z       5[      �� 5\      6.   �� 5]      $��40 �6,   6:   .+�5_        -   5        $ DGUsers��5_   �   $ False��6#   $ False��6:   $ False��6T   $ False��6p    5`        5a   "   $ Код��65      
IsReadOnly$
 True��6]    6B   �� *userId+6]     5b   "   $ Фамилия��65   $
 True��6e    6F   �� *
secondName+6e     5c   "   $ Имя��65   $
 True��6`    6B   �� *	firstName+6`     5d   "   $ Отчество��65   $
 True��6e    6G   �� *	thirdName+6e     5e   "   $ Должность��65   $
 True��6j    6H   �� *division.name+6j     5f   "   $% Тип пользователя��65   $
 True��6s    6O   �� *permission.name+6s   4  .System.Windows.Controls.DataGridCheckBoxColumn  5g   "   $  Верифицирован��69   $
 True��6m    6P   �� *
isVerify+6�     5h   "   $  Заблокировать��69    6P   �� *	isBlocked+6p   5j      �� 5k      -   5        $ btnBlock��5k   F   $��1��6!   $ ��Заблокировать��6.   6q   5l      5n      5o      5p      5q      