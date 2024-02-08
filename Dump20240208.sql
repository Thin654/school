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
INSERT INTO `coin` VALUES (1,'BTC','Bitcoin',_binary '�PNG\r\n\Z\n\0\0\0\rIHDR\0\0\0\0\0\0\0\0\0æ$\�\0\0\0	pHYs\0\0\�\0\0\��+\0\0\0PLTEGpL��\Z��\Z������\Z��\Z��\Z����\Z������\Z��������������������������\Z����\Z����������������������\Z��\Z������\Z��������\Z����\Z��\Z����\Z����������\Z������\Z����\Z����������\Z����������������������\Z����������������������������\Z����������������������������������\Z����\Z����\Z����\Z��\Z������\Z������������������\Z�������\Z�������$����̓�������d��\"��+�\�\������&����ϙ����\�\��\�\���/�Η��-��T��Z��\��ѝ�\�\��������ў��9��Y��\'��7��N����۲��f��`�ե��=�\�~��h��\��\�\��\�\���x��@��I�\�\�����ʏ��^���\��͕��\������W��r�ת��]��1��\\�޺�\�\���b��B����\���E�\�\��� ��4��\��ǈ�\�\����֨�ˑ��m��P�Ӡ�\�\���\���v��\���z��R�\�\��ܵ�ӣ�\�\��ٯ�޸�ɍ��F��\��ݷ��t��*��(��K�\�\���k��o�М�Á�À�\�\��\�\��Ȋ�Ɔ��\��ȋ�Ă��\��Ń�ج�\���ح�\�\������H�ҟ���d�\0\0\0�tRNS\0�\�\����\�\�\�\�LSG�U\n����:3�\r?ѫ�s<\�\�^�ȹ\�r��\�\�mku��\�}�b\�\�\�c�%6NW#p\�1\�gDe*�H����\�iJ�Z�\'A)��/xo�P!��ޡ,��z9�\\���ԣsV\�\0\0 \0IDATx\�\�{tMW\�E��܄�\����H\"!�I\�#(\"B�WQZ\�Z�֫��N\�\�yy4!�^+\�Q\�Poc�Ǣ]Վ\�\�e�\�4k�V�\�Y,3�J\�y\�\�=��~{�\�\�_9\�\����\�~�\�40\n�!����E�j61+.i\�\��F\�L�BL�q�<bM�˚جUT��\�Q!�\rNX��\�A=\�\"\Z��\�\r#\�z�=j!� ��D\�\�K��\"�h\�6{Llt�\'C�	\�\\���(J���3�`\�\�{Ԥ9-\��\��Ƥ׽��a~\�3\�t�\r0%����\r\�\�1\�B4Œ\�\�a\��\0�\�#\�Jt�4;(<\�sh����&\�\�e\0�]��ݝ��{v\Z���\��h\�F\0\�5�U(�4b\�Kc- ��~���\�t\n\�ۂ��]v`\'\�H\�ğ�m\"�1e��R��\� L\�\��-P�!)\�\�\�\�C͔�[ǡ�9\�\�\�)�\��ki&Lbn\�CC�t�!c�\�F2h\Zٜ0�[W?\�_F9\�O^D��wf?TS2SRZn���GE%\�ƍp�[\�TT\�\���$\�!��\\�w\�\"\�)��\�a}���!\��7�P \Z�3\�	\�v��Bg4�� �cZ��\�\�AHM\�,Pg\�?v.1�#q��o�\"�W �^ɀ$b@\Z���\��\�E�WN7h\�/\�LKB�ї�<\�,\�\�x7t\Z�N$�\'\"ڰ�w�\��ۢ�Lc,�\�ů`\\��\�ۿ\Zm\�&\�ffT�:\�\�\r�@��\�\�g�a\�1ß�0\�\� \�\��\�Ql\'�����\�F���*�/����������׿�$0�\��\�\�sQ\���	\�T~\�樮Ksc�����ҺJ\�A�\�?�\�\�:\��9�߽\'�*�iMxҿ**��)�\�hE=)~&q\"p3�\�M	,\�y�D����\Z����X��\Z��*\�!!�\��ɦ\'\�A`2N�)����t\\�Q�\�l\�?G�\n���:\�ڟb�uao\�wʦ$[!n���)KK��B\Z�b�&3���7\�<s�\�%\�j�A*#�q\�JX�(8\�gB�\�_�Ix\�WE̱\��\�\�*�:%\���n�Q/Г�\�@\�;\�]���@y��T�[�6\�0�G�#uю\�\�\�?Uђ\��BM�D�\�?\��Z;\0\�~��q�O�9A@�\�~8��淠\��\��`rn,\��u\�\nb�\� \����\0.\n��:\�[���Mڣ\nz��s�y\�H\�@_Z\�{b\��\�\��\068:N\nO��\0h�\�Vᷭ\�� �t�\�\r/�B�.5D��\0(���#4�=u8����\0e��_���\�y\����\�`�\�\n��Ϗ	,�V�\rNd�\�\�\�\n�b���\Z\Z ���*�a3�	\�M�����l}*\�\"��qxiv\�\�f\0�m�F\�C\�#8п282��\�l6j�6�丨\0^&���շ�&�A�5=3�uf���5C��\�\\(f�f�\�\�M\����\�<\�Y\�n\�\Z��C��\"\0|F\0;*�	\�d\�F��\�\�oY�h5�_\�\��?SD�e�BQi1x\�m�#@u\"���]QZ��	\�x\n��*\0��\�I8X�\'+V6��j̄ps$Ux\\�ϖ�*/�i��!* ��\�#�����\�ek\�5��Jk�\�\�O\�:��\�§\�L���#R�1�R\��\��C�E�ɽ���*�/7�\�E�b�X��p��:`�h\"����\rm$����9:��h8%-T�5�\� �\�4\�G\�#�p\Z^#S.\�\�9`\�p��`\�<DI�=9ҟ*�e*\�I�\�s`N\"��#�O��3�\'\"\��ܡ�<\�Oʍ\�\�S\� (_����\0a6\�+T�ؖ+��l�U&�ش}�P?zF�p�\�Ӕп\�Z�%®mwv\0�\0\��\Z��P�\0lؖ�g=Oe�R�D\0;�����A��\�}�&0P��0H�\�@lב�\nH1��\"��l�����ԕa׶�{eG��\"�}(8@�@�[�ұ\�\\0U8\�h��$O��:%\"G=&�k�`G\�\�R޽@�\� ��	\�#�\��,�\�#\�_�\�M�٦�B��۶g�R`7��΋���\�\�\�,ԡ�\�\�\�G��`�/o\�\0\�	�Styu�C\\T\��\�\'|\�\0�3u5��0T HcI\�Ƌ�*\�n�`#ޝ\�\0]�6\�@��\�v\��)6^ ԗ\�tz#d\�J��\'7w/\�H�\�#�F�u�J�\�3\�ȤJ\0P���?��6$Cm͏*�\�@7��ږ�\r*`5��F�����Pۂ�ɛ\�<�^\n~A-�uX\�\'�g�gD\�˓�e@5#�=���ᤤp�H^[V�P��d\�9�F�ϙ1@c�gA�6d�����ᥳ�w��`C\�)�H�\� h\�\�Ƿ\�I�ldI�\�\rl;�\Z�_����@���e\�\�\�\�\0�9C�R3d�l+�Aҟ�@��5���\ZF\0W`)\�HvU���\�6\�3H8Ζz5u�$ \�Fl}�\��(\�Z\�n\�\�wΟ��61f�H\��\�`f�--ݸj	F\0i4w\�� V\�s\�P�\�\"\rp��F{�t\Zȇ�&mپ�nX�t+[�q\�Pk�&�:X��N\�f*L`?:f\��zY ��ų<-�1&\��G�\���⽌������\�\�\�Q�,��xi�Ա^,b\�\0\�\�\�z\n\�d\�\�وz\�\���v@\�y�����\�GC�]v��:O\r\�\���\�Y\���\�\�\�B\�/���\�\�/�%l�NН\r7`\�\��\�p��w�p�`\�-\"\�ne\�\0�z\�\�\�\�\�qW9d�@\�>�]\�\�Z]XI���Yd\�\�\�@�H�zl\'�X\\\�¹0�\�ԉ\����g\�\��\���\r��P�+ ��+NkBX\�\�\�JH����Z�2�\�U`��\r\�π����90�A\�������Bx\�\�\�:)\n�ʁKW\�\�����{�F��\�I\�\'Dp��2\�gG�+\�\�--.Qc�d�nr|�\�kƌ\0�k�y\�.|��\��3��)ȡx� �\"\�}��:r9W\�\�2Xݔ\���p7@6;�R�aۧJ�N�\�&�\��1#��ô��n\�Rn�\��X\�6f�Q\��\�Y{C��\�\�A\�r0\�\�#�#���\�\�ⷐV=��XFpa��\�\�%����^\�\03�V�4S�S�De�����\�%\"q`�\��:\�n\����������&p[�P���\�:\�>���\�k`*\��*��\�r�\�\�Wᬖ\�\��\"@Ր\�yP��Lg\�.�1#�u���I^\Z,\�Yq�\�´\�\�\Z9\�\�Y0\��9�\�\�\�R�\�\���F\�\�\�S0�\�IYY��jv\�k%��܅\�]5KEda��=A\�!�\�z��,�\"���<�[NC\��\���i\�@�J��\�`օ;pv$H�P�\�3?�~@\�\rcF��r>�v4xJ�ͩf�\�\�g\�\"�3�i_P��fs6\r�[\��,>�4�U �B\�T\�(\"�Q-#�����J��^i�I\��t%J\�}bη�{àt\��J\��@\�:A�-=��\�@@n����I�\0\�eU��R��\��\�[t8�\�,��q���y ԕi�\�z\�Wp`����\0�|Eg��P:\�_\r����etGH��t\��Dǲ��a=\"\0!\�pJ���3�K ��홠\��\��\"�V\�cP\�<�^K�\�2\�>�1\�\r@B� �� �\�\�\n\"\0\�O\0����\�˾�JW\�����=*�\�_4(�H\�\�\�j�9F��c\��9QO�4�I5\'���ic�6��\�h{z�\�\��XH\�U	oXD��Y�����XD%тAc+AX�a\�\�ݙ\�o�\�ov\�\��}\�|�ν�ݩ\�r0�ݯ�~W&\�\�\�I5�\�\�~���Z�D8\�BPޖ�\r0wHF���\�Kg�s`�e6\0�\�0JE��t�\�T\�<\�0$#\0�\�X���\�T	�x���\�\0\�\�U�cp\�\�*�b�kW\�\�Z�\�\�\����\�i�7�@	\�\�Am��sWEm�e\"@%��\���P�N��\�\"�l�e�\Z�\�RÎ\�ҭ�\�\�u�ah�Ӝ�\�]׾\�\�C00\�)O�\�ԅ\�j(\r�L��=\Z��a�8:k����\�\�Q\�ٍ�}�\n\�#�P\�\�2y�\�[��`(E8�?]Z7�\\�6s&X\�}��Fl�^w�7P�\�Wї\n��\�\�$2zF�nD_l�Ӌ�`P��:���7�,z�7Bb���\��ɒ�\�@k)Dd\'a�-�6.\�m6��t�K:`�=�~G`\�>�e\�Q��@\�\�*�2-\�\�{��Cn�B�<n\�yW4X�i�SG�\�dE@�oY�<��c�hCf��\�t$�\\TTevܵ\�-ա��|�Mp��\�^%��C�0p7\0~5��d�3\�3Z��:x��%��\�_�G�J�N%�i@&4A$p��\�\0\� z\0C$p�\��h����@W�\�OL��Z�\�@OPW�oâ�v�\�!��Fgj�K\��yO(�P��Bg\�\�\0�(��2�\��PD��(�0?0D�z?\�:c�\"@\�e\���<\r|j�A\�p\� \��#�>�\�1/\�A�?0���҅��7�\� \��\�`�\��\�t\�\�ꇜ<�\�B\�:\�B(\"@מ�������[�)�:n�6!\�F�|�\��k5�����H��wS(E�\�(s%=\�{��@\�\�Z�\�¿���ߗxf\��!��<f\�=\�,^��V��8{\�Q�8���\�\�\��C1�CNE-\�Ie`yף=*9X�4�\�4C����q\�\�\�L\"�%R�؅�d4���@�`��YY�\�>�\�Ж���\0��.1�d��\�	�c-\�<��\�kw\n�L���L\�i�:{D�\�ȯa�\�\�n:p\'a-��x1v��D\����D\�<~��T\�E�E�^\�F\�e�\ZA�i�h�Dq�b�\�@��<:�!-o�Ѓ�r���T\�\�q6ֆ2D�+R�����\r���e�,�G$F\�f�<nD\�4J�e\�U���r[�ʠ�ҶqE�E�\�\�(mU (���6�4\���\�/)�$\�i\�\�zY#@�t�]�n\�$ry�.\�\�Y��R�	�\�\��8\�\�\�\��\�|q���}<Y�E\0[P#�w\�Ofh�槀�5��\0�e6�_�`3<%l�\�\��\�\�\n��\0GY];\�\0�b\�1�C��k@�\�\r\�[��\�\0Oj@\��\��\�m�`6\0�-!�V\�\"@R�O%��r�\�\0\�\n�+�PMk�] g���\�\"�D�f)\�n�����\0]�5�`L��\�\0\�\"�(P�)��\�g�\r0���\0<�@�;X\�\�\�x���\0��\�!�\��\��U*�\"�ޏs�\�\0���������\�B��\0<פֿ���=��\Z�\0<�Lk\0X�#~\�c�?\0�/3\n\�\�+�8��� }i\rp�~\�c\0@�\�\�:i*��\��\�\�|K\�!\���~��\�ԅn�N\�$Z{r\�R,\�3�\0|.�\�!\�?ֱ\�\0p��{	\�qt��\�i�F��~�\�GKk�<H�\��pR�\�\�[C�oOӅ�Z��\�#\0}̄d��z\�@\�\�gu�ͭ\��3���;�\�}ٟ\�)W\�#`t/�\rȘZ8�`\�_w@2��^ \�`\�/\��\0\�#\0Z\r\��ٽ�R18\��\�!Q\�	���D<bL7\�a\0��z�U2��>x\�\�\��L[�&�1\0���E(͢�>rc��\0B߈m^8\"\0��\0� �f�՟,R~Hi��D=�=��\0�,�G\�GTb���yk*}\�v@�da�)\�D\�\�\�\0�7\0n;�\�ba\0\�w�r(\"@���\0��\�R�3�Gt�C����T0rJ?LTxD\����R)�P������\"4I���3\0�D\�m�\��+\�Q�\�F�I�9\�\0+�\�Oܕ��[�G\��\�\�5I�c!ӭ`���J\�싐�*\�}��\n��\�0�޳b\02W�\�Op�Ǟ\�&)���R��4�1�k�+Y5z\'B����Nh&\�I�v6\�u`\�_	r2\"\�By�\�\�a~\��/\�Z\n\�\0�\Z�Q�\�1	�ܸӒ{̶\�]=s�EA@=\\ݬ\Z@�J!�8e��ޙJ��AFj[R ��\�c�Z\�_�\��W\�rJ\":�~�1�2�j﹢>(?��\�\�>fW9\�	0f\0��Wf<\�|\�z\��\�޽{�\ZN�\�\��\�\���\�\0 +�\�7�\�\0K\�_�B�����\0�\Z=�\�)�+$��\�\�\r`����y\Z@�B9�j6A+�΁��?�\�\�Tlo@O�5>V\�\�\�T��0z����\� \�!1�1���\��^H�.�a�\���\nD�-h�7 ��\�i��/P� �^\�$h\0�����D�&\��}�a�\�l\����\0V�[`�g!�x�<��d\n	\�1%\r`�\�\�A\r�3�c}+.��Cj\Z\�<P������ki�Ɠ\0 q�zp�\��y(N\��\�\0͠x{\�8}�G}�\�Au��\�d��\�.�(f\0\�@q�\��\�,g�B� ��\�β\�\0�c�\�\0�[�j\��Wlw�\�\"�I`���\�\0n/h�b��	|�\�F�g��\02�Q�����\rc�G��O�(��f`��\�f�q\�#��\��bk��Կ�\Zelן�\�\0\�\0)�\�w\�\�4T\�\�\�I4\�^a\0 � XR$\���\"c��o��\�1�Z��\�I\��\�ߢ5�.�-OַGg�2��(�Q�\rpv�`	]]K�\\&(H\�3\��\'kT,�(��a\�z���\"\�\0���#@\�\0L�:\�\�@���H�7Uz ôpk0P�՟��\� ���� �W\"2\�\��5\�E�\�sh#@��\�\�W��\�\�z����?>L�\0�#kg\��\�\�)\0����p�&\�\�0P7��W\�C\�2\Z�\�#��A%\�0�#������\�yK\�[$\��/a�\��P\0\��\�`�g\�\�e�ĵ\�\']����\��8?>�\�\�7���\0��>�\�~�Y�ض�\�aO�*�a\'�צ]��\�\�\0]�<�\�2o��>���\����{(�\\TQ�_)��h�\'.\�F�6���W/ֽAm\0e��PF�o)\"@���\r0�^\��\0�pC\��or�`\0�/e�\0\��\n���Z���\��\'�TG��`\�\�\r@�\0��.3�\0\�\�{X)U�\�\�Z���_�l\0�)��G�\06\�O\��\'\��M\� U�\0�ກ�\�R-`�;��\�TP?�CH\�\�>d�`��	�������F�\0���#,QuPkX\�J�\��*���\�Zx��\�13\0Y\�g\�f��\�\0�f�?q��:�\r\�0Ñ�ȯUo�\\��;H�J#	�\�$���\�y����d�\�a�`\�\�cl\0�\�b\0U\�꟫\�%�1�9�\��s\rZ\�\��\��\'+\\!�2?ߝ�����K����\�\�\'\�3������`Q\�DPA�U���\\�V\�q*)�\�\�&�vj�u�m��\�m\�x\�^̫\�/sibқ-Kv���\�\�n�\��f��Z\�\�\�}\�\����|\�y?8�}]�P�e7�w>;�	~����d��\�K<�	�\�p`B��\�me\�u���\�=f�Ik#@MT��{7D5AF#�SW\0	�M�\�W����o`8�&_�T�\�\�\�\�}�{&#�K񶀼26\0L\�\�\�`G���$�8w\�\��72�y�\�3M�\0a�\�\r@K�*��`z�d׏�]���W%�y�\�W�֔ȟt���e\�\�c�`[��Ku�4\0�^\�6;߾��\��\�*G/)ę\�e��~�	\�\Zr���U\�\��r�1G\0�r��9�\�Jm\����\\��ʬ`Pu6\�\��u\��\�\"�\0\�.RT \�Ͷ~\'�P1)l\�10d�C\�\����SaugEn�\n\r@\�JT�\r\��*V�=;����D���\"��\�W\� ���W[����~	�+iT�H�Š�@�\�})��\�M�� �D�\���J\0bB��,\�`�#�LHCy�>b\�\�,䡴� 1�1�(+���2�P6?1f�(i��S�T�S@*A.J\'B ��!%ĉYX\�?��\�j\�r\���ֈ=Ay��\Z�q�q. #S����٠l}\�\�\�\�\�#.x\"\�Jqb�iI�s��\�\�E^R�rGtI$&�d>qE�g�$\�c$ޤ�\�d��ġ�\�I����n.#;)T����d�o&n◤ά��x6\ZB�gj$\�g#\�\�YĽ�*䘩\�j�H�	e$�\�Lbp\�8�տ��1��<�\�Y�n\r��NLGbqN#\��M��p�\�\"\�t��H@\���\�Tb$1pU,���\0	\�;�-�w-�۽$�D\r2>q\�\�F��.\"\�\�m�I|�\�C\�\'iB���Q\�����V\�-#ﷆ�IC\�\�!\�\�\��-��-�\�\�!U\��h+���ߨ\'-��`�G֭fҪuȿ��4\�BЪ����\�;�\�\��\�	\�,jt\�)\�E���lj1��\�H�}CZ����fj\�He���adT3��\�\rf\�}\�`D�[�:d}��T��\�~>r>A\�\�\'\�\��\�s�#Q\�\�=�|\�\�\��?\�\�\�zd��)Q�`�d%�\�s:�-q\�w� \�S��z\�\0\0\\IDATd\�L\�\�\'\�a`������r��Ϡy�\�e\���jdxF��$���\r;��p�8���R��\�\�<Ww\�Z]7��Čc\��\�\��\�l\��\���\��\�ʜ\�\�ss�~�\�\�I�zd$���)&\�\�\r�<�\�!\Z^\�e\�O��*\��/ e׆_L�c#�s���*7S\��g��+��\�d����R\\\�l�\�[��-�\�Ԥ\�W�k&���\�˔.\�x�\"W.�8\�\�l~\����\��Y\�\��Y�,NwYwo���)qX±��fԖ�ebq�`%\\s\�\'�-%�@�\�w.�#{X�}�K��҇�xGޜf\� :\�wԖ�V��\�C��\�`=~2,�\��PE�Rr\�UR\�a�\�E����-,�=-׺}\0\0\0\0IEND�B`�',37170);
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
