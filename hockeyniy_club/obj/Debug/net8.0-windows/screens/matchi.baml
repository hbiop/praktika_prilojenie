   M S B A M L   `   `   `  ����I  Ehockeyniy_club, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:hockeyniy_club.screenshockeyniy_club.screens  5   	   #    hockeyniy_club.screens.matchi   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:hockeyniy_club.screens     5   	     � Title$  matchi��5   	   $	��450��6   $	��800��6%   .��5	      �  � RowDefinitions 5
   
   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   �� -   5        $��
myListView��5       �� View 5      �� 5      .P�5      �� $#��Дата проведения��6%    �� DisplayMemberBinding 6>   �� *DataProvedenia+�� 5      $��Время начала��6%    6;   �� *VremiaNachala+�� 5      $��Времмя конца��6%    6;   �� *VremiaKonca+�� 5      $%��Домашняя команда��6%    6?   �� *DomashnyaKomanda+�� 5      $'��!Команда соперника��6%    6@   �� *
Sopernik+�� 5      $.��(Счёт домашней команды��6%    6D   �� *
SchetDom+�� 5      $!��Счёт соперника��6%    6=   �� *
SchetSop+5      5      �� 5   
   -   5        $��Удалить��5      $
��Left=�6#   $��	85,54,0,0q�6>   $��1��6Q   $	��Top=�6^   $	��125��6v   $��30��6�   6�   �� 5   
   -   5        $��Изменить��5      $
��Left=�6$   $��
545,56,0,0q�6?   $��1��6S   $	��Top=�6`   $	��120��6x   $��32��6�   6�   �� 5   
   -   5        $��Добавить��5      $
��Left=�6$   $��305,137,0,0q�6?   $��1��6T   $	��Top=�6a   $	��150��6y   $��35��6�   6�   5      5      