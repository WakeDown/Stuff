CREATE PROCEDURE [dbo].[get_employees_bithday]
    @day DATE = NULL ,
    @month INT = NULL
AS
    BEGIN
        SELECT  *
        FROM    employees_view e
        WHERE   ( @day IS NULL
                  OR ( @day IS NOT NULL
                       AND CONVERT(DATE, e.birth_date) = @day
                     )
                )
                AND ( @month IS NULL
                      OR ( @month IS NOT NULL
                           AND MONTH(e.birth_date) = @month
                         )
                    )

    END