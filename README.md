# KASKAD_DistSync
Программа для переподключения распределенной системы к серверу

Для корректной работы программы необходимо:
1. Проследить факт запуска программы KASKAD_DistSync.exe (Не всегда запускается с первого раза из-за проблем с COM-объектом WinCC OA)
2. Запускать программу KASKAD_DistSync.exe от имени **Администратора**
3. Изменить в файле конфигурации "KASKAD_DistSync.exe.config" переменную system на имя системы заданное в проекте "Каскад"
   В текущем примере задана конфигурация для куста №1
    ````XML
    <KASKAD_DistSync.Properties.Settings>
      <setting name="system" serializeAs="String">
        <value>1</value>
      </setting>
      <setting name="dp" serializeAs="String">
        <value>_DistManager.State.SystemNums</value>
      </setting>
    </KASKAD_DistSync.Properties.Settings>
    ````
4. Открывшееся окно консоли оставить открытым на протяжении всего времени работы
---
- [x] Проверка состояния связи с сервером 1 раз в 5 секунд
- [x] Принудительный запрос времени с сервера
- [x] При неудачном подключении перезагружается Distribution Manager
