-- (c) RJF - 2016_05_10
-- 'SVN_dbCasino_IN19_TESTDATEN_HIGHSCORE_2016_05_04_RJF.sql'
--

use dbcasino_in19
go





--########################################################################################
--		tblHighscore:		PROZEDUR zum Eintragen der TESTDATEN für tblHighscore!
------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------

-- NEUE VERSION!!!!!!!!!!!
--------
if OBJECT_id(N'pHighscoreTestdaten') is not null drop proc pHighscoreTestdaten
go
--------
		create proc pHighscoreTestdaten
		as
				declare @fkspielBeginn int = (select top 1 IDSpiel from tblSpiel order by IDSpiel asc)
				declare @fkspielEnde int = (select top 1 IDSpiel from tblSpiel order by IDSpiel desc)
				
				declare @fkspiel int = @fkspielBeginn
			while @fkspiel < @fkspielEnde
			begin

				if @fkspiel is not null
				begin
						declare @punkte float(14) = 100	
						declare @i int = 0
					while @i < 152
					begin
							insert into tblHighscore(Punkte,Spieler,FKSpiel,Datum) 
									values (round(@punkte,1),'MaxMuster',@fkspiel,getdate()) 
						set @i+=1
						set @punkte=@punkte+@punkte*0.0251
					end
					set @fkspiel+=1
				end
				else
					set @fkspiel+=1

			end
		go
--------
/*
exec pHighscoreTestdaten 
---- delete from tblhighscore
select * from tblhighscore
*/
--########################################################################################







--########################################################################################
--		BEGIN:				T O P _ 1 0 0 - M e t h o d e:
------------------------------------------------------------------------------------------
-- Methode, um den Top100 Minimum-Wert zu eruieren, der zum Highscore-Eintrag berechtigt.
--	   ==>  wenn der aktuelle Spiel-Highscore größer als dieser Min-Wert ist, befindet er 
--			sich unter den Top100 und darf eingetragen werden (lt. unserer Definition).
------------------------------------------------------------------------------------------
--	1. FUNKTION!!!
--------
if OBJECT_id(N'fTop100') is not null			drop function fTop100
go
--------
	create function fTop100(@refSpiel varchar(50))
		returns table
	as
		return(select top 100 Punkte, FKSpiel from tblHighscore
					where FKSpiel = (select IDSpiel from tblSpiel 
					where Spiel = @refSpiel) order by Punkte desc)				
	go
--------

-- select * from dbo.fTop100('escalero')
-----------------------------------------------------------------------------------------
		-- 1. Proc erhält als Parameter: Punkte (= möglicher Highscore), Spiel
		-- 2. Proc sucht dynamisch nach FKSpiel, anhand Eingabe von 'Spiel'
		-- 3. Proc prüft, ob der Highscore-Wert größer als der kleinste Top100-Wert ist,
		--		damit er als gültiger Highscore eingetragen werden darf. (Bei Gleichstand
		--		zählt der früher erreichte Score lt. unserer Definition mehr!!)
		-- 4. Insert wenn gültig, Rückmeldung wenn ungültig;
-----------------------------------------------------------------------------------------
--	2. PROZEDUR!!!
--------
if OBJECT_id(N'pHighscoreTop100Min') is not null	drop proc pHighscoreTop100Min
go
--------
		create proc pHighscoreTop100Min
			@punkte float(14),
			@refSpiel varchar(50)		
		as			
			declare @topMin float(14) = (select top 1 punkte from dbo.fTop100(@refSpiel) 
										order by punkte asc)			
			if @punkte > @topMin
				begin
					insert into tblHighscore(Punkte,Spieler,Datum,FKSpiel) values
							(round(@punkte,1),'MaxMuster',getdate(),
								(select IDSpiel from tblSpiel where Spiel = @refSpiel)) 
					select 'Congrats, valid entry!' as [Status], round(@punkte,1) as 
								[YourScore], round(@topMin,1) as [NewLowestEntryToBeat]
				end
			else
				begin
					declare @sorry varchar(60) = 
						'Sorry, score does not qualify for highscore entry!'
					select @sorry as [Status], round(@topMin,1) as [LowestEntryToBeat]
				end
		go
--------
------------------------------------------------------------------------------------------
--		E N D:				T O P _ 1 0 0 - M e t h o d e:
--########################################################################################
/*
exec pHighscoreTop100Min 13000, 'escalero'
exec pHighscoreTop100Min 381.3964, 'escalero'
exec pHighscoreTop100Min 800, 'roulette'
exec pHighscoreTop100Min 8000, 'roulette'

*/




--########################################################################################
--	ALTERNATIVE PROZEDUR, DIE NUR EINEN WERT - DEN NIEDRIGSTEN Top100 WERT - zurückgibt
--########################################################################################
--------
if OBJECT_id(N'pTop100Wert') is not null			drop proc pTop100Wert
go
--------
	create proc pTop100Wert
		@refSpiel varchar(50)
	as
		declare @topMin float(14) = 
		(select top 1 punkte from dbo.fTop100(@refSpiel) 
									order by punkte asc)	
			select @topMin
			
	go
--------
--########################################################################################
-- exec pTop100Wert 'slotmaschine'



----
-- select * from tblhighscore
----

