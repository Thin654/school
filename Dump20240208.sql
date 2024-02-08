-- MySQL dump 10.13  Distrib 8.0.34, for Win64 (x86_64)
--
-- Host: localhost    Database: projectmax
-- ------------------------------------------------------
-- Server version	8.0.34

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `bank`
--

DROP TABLE IF EXISTS `bank`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `bank` (
  `idbank` int NOT NULL,
  PRIMARY KEY (`idbank`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `bank`
--

LOCK TABLES `bank` WRITE;
/*!40000 ALTER TABLE `bank` DISABLE KEYS */;
/*!40000 ALTER TABLE `bank` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `coin`
--

DROP TABLE IF EXISTS `coin`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `coin` (
  `coincode` int NOT NULL,
  `symbol` varchar(45) DEFAULT NULL,
  `namecoin` varchar(45) DEFAULT NULL,
  `icon` blob,
  `rate` int DEFAULT NULL,
  PRIMARY KEY (`coincode`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `coin`
--

LOCK TABLES `coin` WRITE;
/*!40000 ALTER TABLE `coin` DISABLE KEYS */;
INSERT INTO `coin` VALUES (1,'BTC','Bitcoin',_binary '‰PNG\r\n\Z\n\0\0\0\rIHDR\0\0\0\0\0\0\0\0\0Ã¦$\È\0\0\0	pHYs\0\0\Ä\0\0\Ä•+\0\0\0PLTEGpL÷“\Z÷“\Z÷’÷“ù”\Z÷“\Z÷“\Zø’÷“\Z÷“ö“÷“\Z÷“÷“÷“÷’÷“÷“÷“÷’÷“÷“ö“÷’÷“\Zö“÷“\Z÷“÷“ø’÷’ö’÷’÷“÷“÷“÷“÷“\Z÷“\Z÷“÷’÷“\Z÷’÷“ø’÷“\Zø’÷“\Z÷“\Z÷“÷“\Z÷’÷“÷“÷“÷“\Zø’÷“÷“\Z÷’ù“\Z÷“÷“÷“ø’÷“\Z÷“÷’÷“÷“÷’÷’÷’÷’÷’÷“÷“\Z÷“÷“ö“÷“÷“÷’ö“ø“ø”ø’÷“÷“÷“÷“\Z÷“ø’÷“ø’ø“÷“ø’÷“÷“÷“÷“÷“ù‘ø’÷’ø“ö’\Z÷“÷“\Z÷“÷“\Z÷“÷“\Zö“\Zù“÷“ù‘\Z÷’÷“÷“÷“ø’÷“÷“÷“÷“\Z÷“ÿÿÿ÷“\Z÷”ÿþþ÷˜$þüúûÌ“÷“ÿþýù¶d÷—\"÷›+ý\í\Ùÿýü÷˜&ÿþüûÏ™þýûý\è\Ïý\ì\Ö÷/ûÎ—÷œ-ù®Tù±Zþö\ìûÑý\ë\ÔþýúþøñûÑžø¢9ù°Y÷™\'ø 7ù¬NþùóüÛ²ú·fù´`üÕ¥ø¤=ú\Â~ú¸hþó\çý\ã\Äý\æ\Êú¿xø¥@ø©Iý\æ\ËþûøûÊù³^÷•ü\à¼ûÍ•þ÷\ïþûöù°Wú½rü×ªù²]øž1ù²\\üÞºþ\ï\Þùµbø¦Bÿÿþý\à¾ø§Eý\ì\Ø÷– øŸ4þô\èûÇˆý\î\Û÷•üÖ¨ûË‘úºmù­PûÓ ý\ê\Ñþð\àú¾vþõ\ëúÁzù­Rý\ç\ÍüÜµüÓ£ý\â\ÂüÙ¯üÞ¸ûÉø¨Fþò\äüÝ·ú½t÷š*÷š(ùªKý\è\Îú¹kú¼oûÐœúÃúÃ€ý\ä\Æý\ç\ÌûÈŠûÆ†þ÷\îûÈ‹úÄ‚þñ\âúÅƒüØ¬ý\áÀüØ­ý\å\Èþúõø¨HûÒŸþùôd™\0\0\0tRNS\0ý\æ\êöþû\â\î\Æ\çLSGñU\n’€üð³:3ƒ\r?Ñ«²s<\Ì\à^ôÈ¹\åróù\É\Ãmku»\í}b\Ø\Û\é£c•%6NW#p\×1\ÎgDe*›H†§­™\ï€iJ¡Z°\'A)‹Ÿ/xo¥P!Á‰Þ¡,›—z9©\\½·Ô£sV\Ï\0\0 \0IDATx\Ú\ì{tMW\ÇE’›Ü„›\ä‰H\"!¢I\Ä#(\"BˆWQZ\êZŒÖ«¥N\Ç\Ùyy4!¢^+\êQ\ÃPoc¨Ç¢]ÕŽ\Ç\Âe˜\Æ4k´V—\ÕY,3÷J\åy\ï\É=û¼~{Ÿ\ß\ç_9\î\Úûû½\ç~÷\ë·40\nž!£¦ú§Eµj61+.i\è\àF\ãL¦BL¦q<bMŠËšØ¬UTšÿ\ÔQ!ž\rNXøö\è‘A=\ã\"\Zš‰\Ì\r#\âz=j!ö «„D\Ç\ÍKŠ÷\"òh\Ô6{Lltö\'Cô	\È\\ð…(J£¤—3ú`\ß\Ç{Ô¤9-\Õð\èúÆ¤×½±Ÿa~\ï3\ætµ\r0%¥œ…ý\r\ê‹\Ö1\ËB4Å’\Õ\å½a\Øó\0ž\Ú#\ÎJtÁ4;(<\Ðsh©“ø•&\è\Úe\0†]˜›Ý€ {v\ZŽ´þ\ê÷h\ìF\0\á5´U(¾4b\ØKc- –±~¾¨Ž\Út\n\ìÛ‚€¥]v`\'\ÔH\ÅÄŸ‘m\"À1eº£Rªö\æµ L\Ð\îü-Pœ!)\Â\Ý\Ó\ßCÍ”£[Ç¡„9\Í\è€\Ê)ò\ê÷ki&Lbn\éCC¹tò!cƒ\ËF2h\ZÙœ0Ž[W?\Ü_F9\äO^D¸ wf?TS2SRZn°¦÷GE%\ÚÆp…[\äTT\Õ\åŸþŒ$\Â!‰þ\\Áw\ä\"\Â)½‡\ãa}¸!\Óð7¸P \Zü3\ã	\ç¤vÁõBg4‰ò ÀcZÀÁ\ã\ã‰AHM\Æ,Pg\Æ?v.1ñ#q• oõ\"£W ª^É€$b@\Z‡¢ò\Ï”\íE‰WN7h\Ð/\ÅLKBŠÑ—‰<\Ó,\Ä\Ðx7t\ZŒN$†\'\"Ú°òw›\é…úÛ¢ÀLc,ó\ÞÅ¯`\\²†\àÛ¿\Zm\Ã&\ëffT½:\Í\Ó\rµ@ƒ’\×\Æg‚a\ä1ÃŸ£0\Ø\× \Å\èü\ãQl\'«„ðõ\ÏF¡ó*÷/üú‹¿üøÿóñ×¿¾$0\ãò\Ä\ásQ\àú‰	\çT~\ï æ¨®Ksc¸œœ•„ÒºJ\ãAü\é?°\ê\ê:\Ö÷9“ß½\'Š*iMxÒ¿**•ˆ)ü\èhE=)~&q\"p3ü\ÓM	,\à¢yŸD”’–ö\Zµ ŽôX˜Ÿ\Zž€*\Ê!!™\íŸýÉ¦\'\ÃA`2Nþ)º±ªÿt\\ûQŸ\él\ê?Gÿ\nñ“›:\âÚŸb¸uao\íwÊ¦$[!n’…š)KK¦‡B\Z£bŠ&3´÷£7\ê¥<s™\Ù%\æj©A*#£q\ïJX™(8\ígB¥\ÔÂ”_ÿIx\ìWEÌ±\Ðõ\ï\ì†*©:%\ÔøônþQ/Ð“‚\ï¢@\ê;\à]¸ú÷@y´ Tý[¡6\Ú0õGÀ#uÑŽ\×\à\é?UÑ’\ÐôBM´DÁ\Ò?\ÇÿZ;\0\Ô~ñ÷qþOû9A@³\Â~8ÿ¯æ· \èŽ\ëº`rn,\×ÿu\Â\nb‡\È \Üÿ£©\0.\nÁý:\Ò[÷¢MÚ£\nz’¨s•y\ïH\Ô@_Z\ê{b\Ïÿ\è\Îœ\068:N\nOÀóŸ\0h®\ÛVá·­\Øû ¦tª\Ð\r/þBŒ.5D‚ñ\0(’ô¨#4û=u8‚½‰ñšŸ\0e¾þ_ùþ‚\Íy\ÜÀ¬ñ\Ê`ö\ë\n‚Ï	,šV•\rNd¾\Ã\Ö\ä\nðb‚ö¾\Z\Z ýþ*ªa3Á	\æM®þl}*\Ô\"¿„qxiv\ï\èf\0°m«F\ÛC\Ü#8Ð¿282Á±\Ãl6j‘6¥ä¸¨\0^&ˆ°’Õ·€&óA¹5=3Àuf›¥Á5C³ø\Ø\\(f€f›\Õ\âM\Õ÷€ñ±\ä<\ØY\Çn\Ã\Z«½CŒ“\"\0|F\0;*—	\çd\ÐFšð·\í\ÂoYóh5õ_\È\Ë?SD€eùBQi1x\Ìm#@u\"À±Š]QZ¾´	\æ«x\n˜—*\0¢ \ÈI8Xõ\'+V6—jÌ„ps$Ux\\óÏ–¬*/ƒi‚†!* ›ý\Å#À§ ¹…\åek\à5¯Jk€\Ü\èO\Ö:ùó\ÜÂ§\àL¨†þ#R¹1ÀR\Ñ°\ÜñC·EžÉ½«–* /7ú\ÓE€býX§©pŒ£:`«h\"À±‡þ\rm$ ´þ­9:ô¡h8%-Tð5¸\é ¥\ë4\ãG\å#€p\Z^#S.\Å\Ó9`\ÑpŸ‡`\Ã<DIý=9ÒŸ*œe*\ØIô\Äs`N\"Àþ#€O‹½3Ž\'\"\Ø§Ü¡ñ™<\éOÊ\ì\ÌS\ì (_¥À•\0a6\Ô+T¡Ø–+ýl´U&ŽØ´}ŸP?zFñp¬\ÙÓ”Ð¿\ÄZÀ%Â®mwv\0‰\0\çÁ\ZÀ²P¤\0lØ–¢g=Oe‚R£D\0;¿•¯ˆ—Aœª\ê}©&0P°‘0H¶\Ú@l×‘š\nH1‘\"€l¹ú‡‚–Ô•a×¶«{eG€¾\"€}(8@¦@ž[¾Ò±\ç\\0U8\Êh°‘$O:%\"G=&¸k¨`G\Ö\ÕRÞ½@¶\éˆ Žˆ	\Ä#À\Çý,ö\Ð#\à_ƒ\åMƒÙ¦ûBýœÛ¶g¯R`7³ÀÎ‹ôúû\Â\Ü\æ,Ô¡ð\à\æ\åªG€ `®/o\Û\0\Ö	®StyuõC\\T\àš\è\'|\Ý\0¤3u5¨†0T HcI\éÆ‹›*\Ýn¸`#Þ\Ò\0]€6\èº@Á¹\ïv\îû)6^ Ô—\Êtz#d\ÞJ’\'7w/\ØH¥\Û#õF¨u‚Jœ\à3\ØÈ¤J\0Pƒ¨¤?¯€6$CmÍ*€\Û@7ðõÚ–¼\r*`5¯ÀFŒô¹€‘PÛ‚€É›\Ã<Á^\n~A-¬uX\è\'±g¾gD\ÒË“‹e@5#€=––ÿá¤¤pœH^[VµPµ³d\Ï9®F€Ï™1@c‰gAÀ6d³ Ÿþ÷á¥³Ÿw‰‹`C\Ú)‘H°\í¸ h\Ä\ÑÇ·\í—IñldIº\Æ\rl;ö\Z’_²º”@ˆ›”e\à\Ö\É\Ë\0ñ9CR3d¡l+ŽAÒŸ¥@ˆµ5û³À\ZF\0W`)\ØHvUÿ¦½\á6\â3H8Î–z5uµ$ \àFl}ø\Ïõ(\í¢Z\Ân\Æ\âwÎŸþ‚61f€H\×ô\ï`f --Ý¸j	F\0i4w\í†ñ V\Ús\ïPñ\å\"\rp“¹F{¸t\ZÈ‡¥&mÙ¾ñ´nXÿt+[ðq\å”Pk¶&ÿ:X¨›N\ßf*L`?:f\ßñ•zY ÷ÁÅ³<-ô1&\ÙñGý\ÂÀúâ½Œô’¹³›Á\ë\ç\ÎQý,ûxiÔ±^,b\Ö\0\ä\Ò\Çz\n\íd\á\ÆÙˆz\ë\Â†¹v@\×yœ„\ßGC˜]v…:O\r\åŸ\ß½‹\êY\æÁ´\ß\×\ÙB\Ñ/À‡…\Ã\Ä/‡%l³NÐ\r7`\ï\Í÷\Ýp§õw€p´`\à-\"\ïne\Ý\0þz\î \Ð\ê\Î\äqW9d«@\é>°]\ä\ÏZ]XIœ„²Yd\É\Ó\å@»H¤zl\'óX\\\ÅÂ¹0»\ÈÔ‰\ëûÁÿg\Ë\à—\çóû\r˜‰P–+ “À+NkBX\Ù\×\ÙJHòÿ°Zø2¸\ØU`±±\r\àÏ€³¹ —90ÀA\é•º°û‰ŠBx\Õ\Ä\Ç:)\n’ÊKW\è˜\í±œ¯öüý{µFÿ€\ÖI\Ç\'Dp ÿ2\égGó+\ß\Ñ--.Qcùd´nr|\ÈkÆŒ\0ûküy\Ç.|¦ø\äü3Àº)È¡x¸ ”\"\Ô}œ:r9W\Ù\Â2XÝ”\èðŠp7@6;žRþaÛ§J¾N\ê&·\Éð¢1#À§Ã´³‡n\ìRn‰\Ö’X\È6føQ\ìÿ\ËY{C©³\È\ëA\ír0\è\Ù#€#Ÿ¹¥\Ì\äâ·V=šòµXFpaˆ¶\æ\á%ð¤žš^\Ç\03ŒVº4S›S¦De’€ºª\î%\"q`­\Â :\×n\Ê‚€öŒÿ®¶þÁ&p[ùP­\å:\à>œ‚\í‚k`*\à* Š\ír÷\ï\ÓWá¬–\á\ì•\"@Õ\àyPÿ´Lg\Õ.ò1#Àu©Ÿ±I^\Z,\ÓYqµ\êÂ´\Ã\à\Z9\ß\ÈY0\Ì³9À\ê\Í\ÝR°\ê\àù‹F\Î\ä\àS0½\ÆIYY ˆjv\îk%‰žÜ…\Ò]5KEdaÀ=A\à!”\îzµ†,€\"¡ü¨<ú[NC\é®ø\êú¿i\Ð@½J¯”\Ú`Ö…;pv$H³P‘\Ö3?¬~@\è\rcF€ûr>Žv4xJ‡Í©f€\Ù\àg\í\"À3Ši_P–„fs6\r´[\Ãð,>¢4ÀU öB\ÕT\Ð(\"ÀQ-#€‹”øJ—½^i€I\àšt%J\ä}bÎ·”{Ã t\ÙÀJ\ÌÁ@\Ã:A©-=‡«\Ý@@n»”…I¿\0\ÒeU»‚R¶\Èý\Ð[t8¤\Ï,•—qð¸¤y Ô•iÁ\ìz\çWp`€Ÿ´\0„|Eg€ƒP:\í¥_\r‰€ŽetGH‹¡t\Úó«DÇ²¯ÿa=\"\0!\ç¨pJ¯¥ó3¬K ¤„í™ \ç“Á\ì€\"¬V\àcP\à<”^K­\Ð2\à¦>ƒ1\Æ\r@Bž šƒ ½\Ê\×\n\"\0\åO\0œ¡¡\ÏË¾¶JW\á²Ÿûö®=*Š\ë_4(”H\Õ\Û\Ôj¢9F­c\Òú9QO“4¦I5\'©§icš6§­\Çh{z›\è\ÌòXH\ÄU	oXD òY”‡ˆòò…‚XD%Ñ‚Ac+AX–a\ç\ÎÝ™\ßo˜\ïov\ç\î÷}\Ì|÷Î½¿Ý©\ár0¼Ý¯ñ~W&\è\é\ÊI5ƒ\á\í~±¨•Z D8\ÝBPÞ–˜\r0wHF€«®\ëKg€s`ˆe6\0þ\Ú0JE€ýt€\ÓT\Ê<\Ü0$#\0“\åX•þû\àT	ùx§þŽ\ß\0\í\âUˆcp\Ù\È*„b®kW\Ø\ÛZ \å\Û\àƒ€¨\Ói€7µ@	\Ê\ÓAm€¨sWEme\"@%þ\æòôPðN§ž\×\"€l—eõ\Zš\ÞRÃŽ\ÐÒ­‡\Å\Öuöah›Óœ‚\Ä]×¾\Ð\ÉC00\â›)OÀ\ÙÔ…\Éj(\r L¨¡=\Z‰»a„8:k€”ú\ï\ÕQ\ÖÙü}¿\n\à#¹P\Ï\ê¶2y°\Ø[ÿ`(E8°?]Z7¿\\ú6s&X\ì}€¿Fl•^wŽ7P¯\ÉWÑ—\nðƒ\Å\Þ$2zF€nD_l«Ó‹¿`P½„:±7š,z 7BbŒ©¢\î¥É’š\È@k)ïŽ¾Dd\'a™-Á6.\Ïm6t©K:`ô=…~G`\Ç>þe\ÉQƒ¸@\Õ\Ô*ñ2-\Ð\è{ŒŒCn€BŽ<n\åyW4XiºSG‰\ädE@£oY‚<ücŽhCf¼·\Ñt$û\\TTevÜµ\æ-Õ¡û˜|óMpü­\Ç^%¸C„0p7\0~5ù¹dƒ3\É3Z¡:xü­%¯£\Ö_GJ€N%¯i@&4A$p™†\Ú\0\ß z\0C$pò\ê™hô¿›’@Wò°\ä€OL’±Z\Í@OPWŠoÃ¢ÿv¨\Î!¨›FgjúK\Ä‚yO(’P—Bg\â€\Ø\0©(ô÷2¦\ÐµPD€’(´0?0D€z?\Ð:c\"@\Öe\àŽÀ<\r|j¶A\çp\æ… \àÀ#¯>‡\ã1/\çA–?0¦‡÷Ò…Žþ7\á \Ññ\ë`Š\àŸ\ît\×\îê‡œ<§\ÃB\â:\ÄB(\"@×žŒŒ¨¶ú³ö[õ)¤:n¦6!\ÞFŽ|÷\Ùðk5»ÿƒ‘¨HœŠwS(Eð\è³(s%=\íŽ{ðŽ@\Ä\âZ¼\ÛÂ¿¯¡ß—xf\ÛÁ!—ñ<f\â=\Ò,^™V¿¨8{\ËQ¶8Ÿ…\Å\Õ\ä÷C1ôCNE-\ÓIe`y×£=*9X¢4»\é4C„¦  q\Ú\ã\áL\"€%RŽØ…Ád4¾ƒ¶@³`ð›‡YY \Ö>\ËÐ–ˆ¡ˆ\0¾¶.1žd”ü\á¯	¸c-\Å<ôÁ\ækw\n˜L£ ó¸†L\Âi€:{D€\ÞÈ¯añ\Ò\àn:p\'a-ùµx1v‹¼D\ÐñóÁD\Ø<~€µT\ìEûE€^\ë„F\ée\ZAó¸i±hšDqb£\ä»@ÀÀ<:»!-o÷Ðƒˆr©õ¡T\Â\åq6Ö†2D€+R·ž…À\r¾ŽµeŒ, G$F\Ãf¨<nD\Ú4J—e\ÏU€þ¸r[šÊ ùÒ¶qE²E€\ï\Ð(mU (‘‹6Ž4\Êº‘\à/)Á$\Òi\ë\ØzY#@÷t ]Šn\Ã$ry§.\ê³\äY°ñRŽ	\É\äû8\Û\Ç\Ë\îû\îž|qŸ ¹}<Y¨E\0[P#Áw\éOfhÀæ§€„5¡­\0‰e6À_µ`3<%l†\Ç\ä³\Ð\í\n¤ˆ\0GY];\å\0µb\à1ùC³¦k@ª\è\r\Â[ø—\Ù\0Oj@\Ìó\çµ\àmž`6\0¶-!úV\Å\"@R©O%£r…\Ù\0\Ø\n†+ºPMk€] g„¬\Õ\"€D©f)\à³nü—ª•Œ\0]¥5À`Lþ¢\Û\0\Ñ\"€(P·)¹Œ\Êg»\r0•òŽ\0<Ÿ@½;X\é \å\Ýx•ªŽ\0 \Þ!‹\Êù\ÝÀU*Ž\"°Þs‘\Ö\0¹ ˜öþ¨ö…\êB”Ž\0<ï­Ž¥ =ø‘\Z\0<ŸLk\0X#~\Óc€?\0ú/3\n\Ö\Ù+¦8½õ }i\rp”~\Ùc\0@»\Â\â:i*©½\Éò\î\Ë|K\î!\ê’ ð~œ\æ€Ô…nªN\×$Z{r\ÇR,\Ä3\0|.­\ê!\é?Ö±\Ç\0pƒó{	\ìqt·¯\ÅiŽFšš~þ\ÌGKk€<Hø\ìþpR \å\Æ[C“oOÓ…ðZª²\Ì#\0}Ì„d€z\à@\Æ\ägu¿Í­\Ìò3±¦´;”\Å}ÙŸ\Ê)W\Å#`t/ü\rÈ˜Z8ö`\è_w@2À¬^ \Ã`\Ì/\ÙÁ\0\ì#\0Z\r\ÓÀÙ½õR18\Ñú\Û!Q\ï	‚´ôD<bL7\ìa\0ö€zÀU2À²>xÂ\ì\Ò\Î L[‚&ö1\0ˆ¥ E(Í¢ >rcú\0Bßˆm^8\"\0õ›\0® ŽföÕŸ,R~HiŽD=–=€ž\0‹,ðG\ÅGTb—À¼yk*}\áv@˜da€)\ÞD\Ú\Ä\áˆ\0ô7\0n;ý\êba\0\åw…r(\"@¬„Á\0ª¼\ÑRò3…GtŽC‚¤ôœT0rJ?LTxD\Õ† “R)ªPø°Ÿ•­€\"4I ¹õ3\0ùD\Ñm·\ÏÀ+\é¿Q¥\ìFùIƒ9\Ç\0+û\ëOÜ•§[ÁG\çó™”\è\Ò5I c!Ó­`¾ƒ‚J\æì‹˜*\É}üü\n¥\á0ýÞ³b\02W¹\éOpöÇž\Û&)ÿƒ¾R»‡4Á1Àkú+Y5z\'Bª«Š¨Nh&\äI¾v6\Üu`\Å_	r2\"\ìByœ\È\Ùa~\í’/\ÛZ\n\Ç\0­\ZÀQ±\æ1	œÜ¸Ó’{Ì¶\Ñ]=sžEA@=\\Ý¬\Z@¹J!÷8e¶÷Þ™JÁ›AFj[R ›‹\í€c€Z\×_±\ÂñW\ïrJ\":´~‹1¶2üjï¹¢>(?½¹\æ\Æ>fW9\è	0f\0¸ŒWf<\Í|\Ñz\Ëÿ\ÔÞ½{·\ZNŸ\Ý\Åú\Ë\Õú\Ë\0 +\î7\Ç\0K\Ò_¡B‡†‚þ§\0½\Z= \æ)³+$²¢\ì´\Ú\r`‚£ÿˆy\Z@ÁB9ñj6A+ ÎŸ¬?­\è\ÈTlo@O€5>V\é\Ñ\åT”©0zƒ£ÿø\á \ë!1§1þ°º\è°^Hò.”aª\Ê\nD¾-h€7 •Ž\Ïi¬ñ/Pƒ µ^\ì$h\0²€‡…œDü&\Ø©}üaý\ßl\Ý¸¦\0V¶[`ˆg!€xœ<˜þd\n	\É1%\r`‚\Ä\á²A\rð¢3úc}+.ý¯Cj\Z\ì<PŸðÀ¡«kiÆ“\0 q·zpý\É÷y(N\Ûˆ\Â\0Í x{\×8}G}ý\ÛAuŸ\ædƒ”\Ü.ù(f\0\Û@q¶\Èý\É,g¨B  ¬Ž\áÎ²\É\0ðc \Õ\0¬[ðj\ÛôWlw°\ê\"ÀI`œ±\Ñ\0n/h€b€µ	|Á\ÍFgµÀ\02€Qöœ­ú“\rc‘G€ûOù(­ûf`Œ\Üfq\È#€‘\çýbkü•Ô¿º\Zel×Ÿ¼\ä\0\Ý\0)‚\ìw\×\ä4T\ê\í\ÑI4\Æ^a\0 ý XR$\ëûú\"cµüoª\à1¶ZŒþ\äI\èˆ\âß¢5.µ-OÖ·Ggƒ2ö±(QÀ\rpv`	]]K¦\\&(H\Ø3\âô\'kT,‘(‹üa\ÉzˆŒ½\"\Ò\0Ž°ƒ#@\Ø\0L–:\Õ\Ç@öš£H7Uz Ã´pk0PÂ–ŠÕŸ¸€\Þ ¾¶þ™ »W\"2\Ä\êò5\ÍE´\Èsh#@õ\Å\ÚWý‚\ë\éz°„­¯?>L‹\0¶#kg\à˜\Ù\Ã)\0¤— øp‘&\Ä\ï0P7­ºW\ÌC\Æ2\Zý\É#ýA%\Û0…#À—‘‘Ÿ\èyK\ä[$\Ãö/a«\Ïó®P\0\î‘\æ`—g\Ï\ße¤Äµ\Ä\']²¥Áž\Âò8?>¦\Ð\é7œ¡‰\0»…>ô\ï~žY™Ø¶¥\ã‚aO¿*†a\'®×¦]«¼\Â\ã\0]€<¨\Ò2o€¥>¿™ž\ßœ{(û\\TQ¤_)«hõ\'.\ÓF€6š°ƒW/Ö½Am\0e»ˆPF€o)\"@ §Š\r0^\âò\0ûpC\Åúor’`\0˜/eŽ\0\Èñ\n‘„µZÀµ\Òô\'TGð¢`\ä\Ë\r@ž\0÷›.3\0\ç\Õ{X)Uò\Ò\ÓZÀ‹§_•l\0ò)´µG‹\06\ãO\Òõ\'\ÃúM\á‚ U‹\0½àº\ÈR-`…;ý‰\ãTP?ªCH\Ë\Ì>d’`®	 ¦‚—„´üF‹\0½¦€#,QuPkX\ÏJò‡\áü*“–\ÑZx€…\ï13\0Y\çg\Ýfö«\Ô\0¿f§?qœ:ø\r\Å0Ã‘¡È¯Uoø\\•ú;H˜J#	ª\Ð$ô¡¯\Ôyø”­þd\Ýaµ`\Ö\Ícl\0²\Æb\0U\ÜêŸ«\Ê%€1„9þ\á‡Œs\rZ\è\Æó\ìõ\'+\\!ü2?ß†þ¡£Kµðÿö\î\í\'\í3Œø£„‚€`Q\éDPA™U‹¨õ\\¥V\ëq*)ó„´\Ã\è&ºvju«mš˜\Ým\éšx\Õ^Ì«\Ý/sibÒ›-Kv·ý»\Ù\Õn½\ÙÁf±­Z\Ä\ß\á}\ß\ß÷óð|\ày?8}]†Pùe7Áw>;ª	~ÁðŠd±Á\ÐK<ª	þ\Âp`Bžü\Éme\ëuþ±û\äµ=føIk#@MT¦ {7D5AF#ÀSW\0	’MŒ\ÉW¼³»ýo`8°&_þT¿\Ì\ê«\Þ\Ù}ò{&#ÀKñ¶€¼26\0L\Ü\ä\ä`G´ü‹$«8w\Ñ\Ø—72†y«\È3M\0a£\Ì\r@K¾*¢­`z‰d×€]ý¤€W%ùyû\éWšÖ”ÈŸt¥œ•e\ç\å‹cš`[¬üKuŠ4\0õ^\ä¯6;ß¾øþ\í›\Þ*G/)Ä™\Ãe¾~³	\Ä\Zrœ¤·U\Ú\Úûrÿ1G\0—rù“9—\çJm\íý¶ÿ\\¸ Ê¬`Pu6\ç\åúu\ï‡ý\ç\"\0\Ö.RT \ÄÍ¶~\'ÿP1)l\æ10d†C\Õ\Ùñ±òùSaugEn¡\n\r@\îJTž\r\Ë‘*V¨=;€«¤’Dª¯¾\"©¦\åW\ß ©¨õW[šù“~	¨+iTµH‡Å º@©\Ì})¨§\ÓMªˆ µDˆ\Ã‘„J\0bBÀ€,\Ô`ð#úLHCy¦>b\Æ\í,ä¡´¬ 1¤1‰(+§‘˜2ˆP6?1f¡(i˜S€T”S@*A.J\'B ö´!%Ä‰YX\È?ÿ¯\Ãj\Ñr\ç…˜Öˆ=Ay÷ÿ\Z‰q·q. #S˜—ÀÙ l}\Ä\î\È\Ä\á#.x\"\ÈJqb©iI¯s€¸\á\ÎE^R«rGtI$&­d>qEg†$\Õc$Þ¤ð\ä¨dŠüÄ¡„\ÉI´ü³—n.#;)T®§°düo&nâ—¤Î¬½x6\ZB„gj$\Îg#\Å\ÌYÄ½®*ä˜©\ÜjÀH®	e$§\ÇLbp\â€8“Õ¿“„1ðò<­\ÒYˆn\r‰žNLGbqN#\ÔôM÷“pª\ï\"\×t…—H@\Æœ¦\ÅTb$1pU,³Ÿ\0	\Ë;…-w-þÛ½$²D\r2>q\ï\×F‚‹.\"\å\ãm¸I|Ÿ\âC\à\'iB´“ÀQ\ßþ·®“V\ä-#ï·†ÿIC\ê\à!\â\×\×þ-õ¤-Ÿ\à¾\à!U\Òýh+‚µóß¨\'-Š®`üGÖ­fÒªuÈ¿®˜4\ìBÐªñ¥·ž´\Í;¯\á‹\ã¡ù\Ï	\î,jt\È)\ëEúÿñlj1ÿ»\ÅHþ}CZ‹ÿ‘©fj\ê²He·™¿adT3§„\Ù\rf\ä}\Ý`Dñ[ý:d}ŒüT¥ð\ï~>r>A\á¨\Ð\'\Å\çð\îs÷#Q\ã¿\Ú=‚|\Ó\Ù\îò?\é\ë\ìzd›ö)Q™`‘d%±\ís:½-q\âw´ \ÑS«Ÿz\Ì\0\0\\IDATd\èL\á\È\'\Ãa`¬Œû«ƒ¦r¾úÏ y\ëe\áù‚jdxFú±$§¦¤\r;þ’p§8ü‰™R’“\Î\ê<Ww\ÇZ]7™ÄŒc\íœü\Ø\Øû\×l\Øñ“\ç À¶\Èü\ÒÊœ\Ø\î—ssÀ~\á\çIözd$·‘±)&\ç\ë”\r÷<”\Ú!\Z^\Ïe\êOŠ³*\â÷/ e×†_Lœc#ýs÷‡*7S\å•g¾¦+¼õ\Õdöµ½§R\\\Þló\á[Ÿ‰-‚\áÔ¤\ÂWŠk&ý÷±\ÏË”.\Ûx“\"W.‡8\ï \Þl~\Ìö—\ËøY\Ð\ÚôYÿ,NwYwo¬Áµ)qXÂ±†±fÔ–§ebq°`%\\s\Ö\'-%Á@õ\ä•w.¯#{Xš}ªK¦šÒ‡±xGÞœf\Ó :\ç³wÔ–¸V’—\ÂC•‹\Å`=~2,–\ÈòPEøRr\ÅUR\Ûa÷\ÍEµ³´ÿ-,ú=-×º}\0\0\0\0IEND®B`‚',37170);
/*!40000 ALTER TABLE `coin` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `credit`
--

DROP TABLE IF EXISTS `credit`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `credit` (
  `number` int NOT NULL,
  `identification` int NOT NULL,
  `cvv` int DEFAULT NULL,
  `expiry` date DEFAULT NULL,
  PRIMARY KEY (`number`,`identification`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `credit`
--

LOCK TABLES `credit` WRITE;
/*!40000 ALTER TABLE `credit` DISABLE KEYS */;
INSERT INTO `credit` VALUES (1,123,881,'2023-11-02');
/*!40000 ALTER TABLE `credit` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `customer`
--

DROP TABLE IF EXISTS `customer`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `customer` (
  `idcustomer` int NOT NULL AUTO_INCREMENT,
  `name` varchar(45) DEFAULT NULL,
  `email` varchar(45) DEFAULT NULL,
  `password` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`idcustomer`),
  UNIQUE KEY `email_UNIQUE` (`email`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `customer`
--

LOCK TABLES `customer` WRITE;
/*!40000 ALTER TABLE `customer` DISABLE KEYS */;
INSERT INTO `customer` VALUES (4,'John Do','john.doe@example.com','newpassword');
/*!40000 ALTER TABLE `customer` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `movement`
--

DROP TABLE IF EXISTS `movement`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `movement` (
  `movementid` int NOT NULL AUTO_INCREMENT,
  `coincode` int DEFAULT NULL,
  `date` datetime DEFAULT NULL,
  `rt_price` int DEFAULT NULL,
  `vol` int DEFAULT NULL,
  PRIMARY KEY (`movementid`),
  KEY `mov_coin_fk_idx` (`coincode`),
  CONSTRAINT `mov_coin_fk` FOREIGN KEY (`coincode`) REFERENCES `coin` (`coincode`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `movement`
--

LOCK TABLES `movement` WRITE;
/*!40000 ALTER TABLE `movement` DISABLE KEYS */;
/*!40000 ALTER TABLE `movement` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `trade`
--

DROP TABLE IF EXISTS `trade`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `trade` (
  `idtrade` int NOT NULL AUTO_INCREMENT,
  `customerid` int DEFAULT NULL,
  `coinid` int DEFAULT NULL,
  `transactionid` int DEFAULT NULL,
  `rate` int DEFAULT NULL,
  `date` datetime DEFAULT NULL,
  `long/short` tinyint DEFAULT NULL,
  `amount` int DEFAULT NULL,
  PRIMARY KEY (`idtrade`),
  KEY `trans_coin_fk_idx` (`coinid`),
  KEY `trade_trans_fk_idx` (`transactionid`),
  KEY `trade_cu_fk_idx` (`customerid`),
  CONSTRAINT `trade_coin_fk` FOREIGN KEY (`coinid`) REFERENCES `coin` (`coincode`),
  CONSTRAINT `trade_cu_fk` FOREIGN KEY (`customerid`) REFERENCES `customer` (`idcustomer`),
  CONSTRAINT `trade_trans_fk` FOREIGN KEY (`transactionid`) REFERENCES `transaction` (`transactionid`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `trade`
--

LOCK TABLES `trade` WRITE;
/*!40000 ALTER TABLE `trade` DISABLE KEYS */;
/*!40000 ALTER TABLE `trade` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `transaction`
--

DROP TABLE IF EXISTS `transaction`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `transaction` (
  `transactionid` int NOT NULL AUTO_INCREMENT,
  `customerid` int DEFAULT NULL,
  `credit` int DEFAULT NULL,
  `identification` int DEFAULT NULL,
  `date` datetime DEFAULT NULL,
  `amount` int DEFAULT NULL,
  `transbankid` int DEFAULT NULL,
  PRIMARY KEY (`transactionid`),
  KEY `tran_sa_fr_idx` (`transactionid`),
  KEY `cu_tr_fr_idx` (`customerid`),
  CONSTRAINT `cu_tr_fr` FOREIGN KEY (`customerid`) REFERENCES `customer` (`idcustomer`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `transaction`
--

LOCK TABLES `transaction` WRITE;
/*!40000 ALTER TABLE `transaction` DISABLE KEYS */;
/*!40000 ALTER TABLE `transaction` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-02-08  9:31:31
