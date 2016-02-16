﻿CREATE PROCEDURE [dbo].[fill_work_days]
	--год для которого делаем встаку рабочих дней
    @year INT = NULL , 
--перезаписать дня для года (1 - да, 0 - нет)
    @rewrite BIT = 1
AS
    BEGIN
        SET NOCOUNT ON;
        DECLARE @is_friday_short BIT ,
            @set_oficial_short BIT ,
            @start_date DATE ,
            @end_date DATE ,
            @friday_name NVARCHAR(15) ,
            @saturday_name NVARCHAR(15) ,
            @sunday_name NVARCHAR(15)
	
        SET @is_friday_short = 1
--является ли пятница сокращенным днем
        SET @set_oficial_short = 1
--считать официальные сокращенные дни сокращенными или нет
	
        SET @year = ISNULL(@year, YEAR(GETDATE()))
--текущий год
        SET @start_date = CONVERT(DATE, CONVERT(NVARCHAR, @year)+'-01-01')
        SET @end_date = CONVERT(DATE, CONVERT(NVARCHAR, @year)+'-12-31')
	--т.к. не уверен на каком языке будет выполняться данная функция, то хардкодим пятницу, субботу и воскресенье
        SET @friday_name = DATENAME(weekday, convert(date,'2015-07-24'))
-- точно пятница
        SET @saturday_name = DATENAME(weekday, convert(date,'2015-07-25'))
-- точно суббота
        SET @sunday_name = DATENAME(weekday, convert(date,'2015-07-26'))
-- точно воскресенье

        IF @rewrite = 1
            BEGIN
                DELETE  dbo.work_days
                WHERE   YEAR(date) = @year
            END;
        WITH    sample
                  AS ( SELECT   @start_date AS dt
                       UNION ALL
                       SELECT   DATEADD(dd, 1, dt)
                       FROM     sample s
                       WHERE    DATEADD(dd, 1, dt) <= @end_date
                     )
            INSERT  INTO dbo.work_days
                    ( date ,
                      work_hours
                    )
                    SELECT DISTINCT  t.date , --официальныесокращенные дня из таблицы wd_short_days
                            CASE WHEN ( ( @is_friday_short = 1
                                          AND DATENAME(weekday, t.date) = @friday_name
                                        )
                                        OR @is_friday_short = 0
                                      )
                                      OR ( @set_oficial_short = 1
                                           AND t.date IN (
                                           SELECT   date
                                           FROM     dbo.wd_short_days hd
                                           WHERE    YEAR(hd.date) = @year )
                                           OR @set_oficial_short = 0
                                         ) THEN 7
                                 ELSE 8
                            END AS work_hours
                    FROM    ( SELECT    s.dt AS date
                              FROM      sample s
                              WHERE     --исключаем праздники (таблица wd_holidays)
                                        s.dt NOT IN (
                                        SELECT  date
                                        FROM    dbo.wd_holidays hd
                                        WHERE   YEAR(hd.date) = @year )
  --исключаем субботы и воскресения, кроме рабочих в таблице wd_work_holidays
                                        AND DATENAME(weekday, s.dt) NOT IN (
                                        @saturday_name, @sunday_name )
            
            --добавляем официальные рабочие выходные
                              UNION ALL
                              SELECT    date
                              FROM      dbo.wd_work_holidays wh
                              WHERE     YEAR(wh.date) = @year
                            ) AS t
                    ORDER BY t.date
            OPTION  ( MAXRECURSION 0 )
    END