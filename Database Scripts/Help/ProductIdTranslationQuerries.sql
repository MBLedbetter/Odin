
SELECT * FROM PS_MARKETPLACE_PRODUCT_TRANSLATIONS WHERE TO_PRODUCT_ID = ''

BEGIN TRAN

DELETE FROM PS_MARKETPLACE_PRODUCT_TRANSLATIONS 
WHERE TO_PRODUCT_ID = ''

ROLLBACK
/*
COMMIT TRAN
*/

SELECT INV_ITEM_ID, TRANSLATE_EDI_PROD FROM PS_ITEM_ATTRIB_EX A
WHERE EXISTS( SELECT * FROM PS_MARKETPLACE_PRODUCT_TRANSLATIONS B WHERE A.INV_ITEM_ID = B.FROM_PRODUCT_ID AND B.TO_PRODUCT_ID = '')

BEGIN TRAN

UPDATE PS_ITEM_ATTRIB_EX
SET TRANSLATE_EDI_PROD = 'N'
WHERE EXISTS( SELECT * FROM PS_MARKETPLACE_PRODUCT_TRANSLATIONS 
WHERE PS_ITEM_ATTRIB_EX.INV_ITEM_ID = PS_MARKETPLACE_PRODUCT_TRANSLATIONS.FROM_PRODUCT_ID 
AND PS_MARKETPLACE_PRODUCT_TRANSLATIONS.TO_PRODUCT_ID = '' )

ROLLBACK
/*
BEGIN TRAN
UPDATE PS_MARKETPLACE_PRODUCT_TRANSLATIONS
SET TO_PRODUCT_ID = LTRIM(RTRIM(TO_PRODUCT_ID))

ROLLBACK*/
/*
COMMIT TRAN
*/