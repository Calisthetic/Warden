   M S B A M L   `   `   `  ����G  CWpfWardenAPI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullY1clr-namespace:WpfWardenAPI.Pages.SecurityPersonal#WpfWardenAPI.Pages.SecurityPersonal  5      ;    5WpfWardenAPI.Pages.SecurityPersonal.AdministratorPage   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Clocal1clr-namespace:WpfWardenAPI.Pages.SecurityPersonal     5      -   5          N� Title$  AdministratorPage��5	      .��5      �  � RowDefinitions 5   
   �� 5      $��40 �6   6*   �� 5      $��1 �6   6)   �� 5      6   .+�5   
   �� -   5         ��Name$ txtFIO��5      $��Right=�6$   $��Bottom=�6@   $��0 0 5 5q�6[   $��20(�6l   6|   � 5   
   $��1��6   
���   �61   � 5   
   $��2��6   $	��300��6    � ColumnDefinitions 5      �� 5      $��2* �6#   60   �� 5      $	��100 �6#   61   �� 5      $	��300 �6#   61   �� 5      $��4* �6#   60   .+�5      �� $��1��6   .+�5      �� $��Фамилия��6   $��18(�6+   $
��0 10q�69   6I   �� 5      $��Имя��6   $��18(�6'   $
��0 10q�65   6E   �� 5      $��Отчество��6   $��18(�6,   $
��0 10q�6:   6J   �� 5      $��Пол��6   $��18(�6'   $
��0 10q�65   6E   �� 5      $��Должность��6   $��18(�6-   $
��0 10q�6;   6K   5       �� 5!      $
��25 1q�6   $��2��6'   .+�5"      �� -   5         ��Name$ txbSecondName��5"      $��18(�61   $	��0 9q�6?   6N   �� 5#      -   5        $ txbFirstName��5#      $��18(�60   $	��0 9q�6>   6M   �� 5$      -   5        $ txbThirdName��5$      $��18(�60   $	��0 9q�6>   6M   �� 5%      -   5         ��Name$ 	cmbGender��5%      $��18(�6.   $	��0 8q�6<   .@�5&      ��  �� 
IsSelected$
 True��6#   $��Не выбрано��65   6L   �� 5'      $��Мужской��6#   67   �� 5(      $��Женский��6#   67   5)      �� 5*      -   5        $ cmbDivision��5*      $��18(�60   $	��0 8q�6>    �� DisplayMemberPath$
 name��6K   6f   5+      �� 5,      $	��375��6   $��1��6%   $��2��65   $
��Left=�6I    �� Orientation$ 
Horizontal=�6d   $��Bottom=�6}   .+�5-      �� -   5        	 ��Name$	 btnSave��5-      $
��Left=�6@   $��Сохранить��6[   $��18(�6o   6   �� 5.      -	   5        $	 	btnCancel��5.      $��75 0 0 0q�6D   $��Отменить��6V   $��18(�6i   6y   5/      50      51      52      