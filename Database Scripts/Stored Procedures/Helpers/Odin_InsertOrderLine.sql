
DROP PROCEDURE Odin_InsertOrdLine
GO


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE Odin_InsertOrdLine

	@itemId varchar(18) = '',
	@orderStatus varchar(18) = ''

AS
BEGIN

	SET NOCOUNT ON;

	INSERT INTO PS_ORD_LINE(
		BUSINESS_UNIT,
		ORDER_NO,
		ORDER_INT_LINE_NO,
		PRODUCT_ID,
		PROD_ID_SRC,
		PROD_ID_ENTERED,
		ADDRESS_SEQ_NUM,
		ADDR_OVRD_LEVEL,
		AERP,
		ALLOW_OVERPICK_FLG,
		BCKORDR_CNCL_FLAG,
		CSD_BENEFIT_ID,
		PRICE_PROGRAM,
		CANCEL_DATE,
		CARRIER_ID,
		CARRIER_ID_EXP,
		CCI_REQ_EXP,
		CONFIG_CODE,
		COO_REQ_EXP,
		COUNTRY_LOC_BUYER,
		COUNTRY_LOC_SELLER,
		COUNTRY_SHIP_FROM,
		COUNTRY_SHIP_TO,
		COUNTRY_VAT_BILLFR,
		COUNTRY_VAT_BILLTO,
		COUNTRY_VAT_PERFRM,
		COUNTRY_VAT_SUPPLY,
		CP_TEMPLATE_ID,
		CURRENCY_CD,
		CURRENCY_CD_BASE,
		CUST_BILL_BACK_ALL,
		CUST_BBACK_ALL_BSE,
		CUST_NET_PRICE,
		CUST_NET_PRC_BASE,
		CUST_OFF_INV_DISC,
		CUST_OFF_INV_BASE,
		CUST_PO_PRICE,
		CUST_PO_PRC_BASE,
		CUSTOMER_ITEM_NBR,
		CUSTOMER_PO,
		CUSTOMER_PO_LINE,
		DROP_SHIP_FLAG,
		EXPORT,
		EXPORT_LIC_REQ,
		EXPORT_LIC_TYPE,
		EXPORT_LIC_APPL,
		EXPORT_APPL_DT,
		EXPORT_LIC_REC,
		EXPORT_REC_DT,
		EXPORT_LIC_NBR,
		EXPORT_LIC_EXPIRE,
		EXPORT_LIC_VALUE,
		EXPORT_LIC_QTY,
		FREIGHT_TERMS,
		EXS_TAX_TXN_TYPE,
		FREIGHT_TERMS_EXP,
		IMPORT_LIC_REQ,
		IMPORT_LIC_APPL,
		IMPORT_APPL_DT,
		IMPORT_LIC_REC,
		IMPORT_REC_DT,
		IMPORT_CERT_NBR,
		IMPORT_LIC_EXP,
		IST_TXN_FLG,
		ORD_LINE_STATUS,
		LIST_PRICE,
		LIST_PRICE_BASE,
		LIST_PRICE_ORIG,
		LIST_PRICEORIG_BSE,
		LOAD_ID,
		MAX_PICK_TOLERANCE,
		NAFTA_REQ_EXP,
		ORDER_GRP,
		ORD_LINE_TAG,
		PAYMENT_METHOD,
		PHYSICAL_NATURE,
		PYMNT_TERMS_CD,
		PRICE,
		PRICE_BASE,
		PRICE_ORIG,
		PRICE_ORIG_BASE,
		PRICE_PROTECTED,
		PRODUCT_ID_ORIG,
		QTY_ORDERED,
		QTY_ORDERED_ORIG,
		REASON_CD,
		REPLACEMENT_FLG,
		REQ_ARRIVAL_DTTM,
		REQ_SHIP_DTTM,
		SCHED_ARRV_DTTM,
		SCHED_SHIP_DTTM,
		SED_REQ_EXP,
		SHIP_FROM_BU,
		SHIP_PARTIAL_FLAG,
		SHIP_PRIOR_FLAG,
		SHIP_PRIORITY_ID,
		SHIP_PRIORITY_EXP,
		SHIP_TO_CUST_ID,
		SHIP_TYPE_ID,
		SHIP_TYPE_ID_EXP,
		STATE_LOC_BUYER,
		STATE_LOC_SELLER,
		STATE_SHIP_FROM,
		STATE_SHIP_TO,
		STATE_VAT_DEFAULT,
		STATE_VAT_PERFRM,
		STD_DISCOUNT,
		STORE_NUMBER,
		TAX_CD,
		TAX_CUST_GROUP,
		TRNSPT_LEAD_DAYS,
		TRNSPT_LEAD_HOURS,
		TRNSPT_LEAD_MIN,
		UNIT_COST,
		UNIT_OF_MEASURE,
		UOM_ORIG,
		CNTRCT_ID,
		CNTRCT_LINE_NBR,
		CNTRCT_SCHED_NBR,
		VAT_APPLICABILITY,
		VAT_CALC_GROSS_NET,
		VAT_CNTRY_SUBD_FLG,
		VAT_DCLRTN_POINT,
		VAT_DFLT_DONE_FLG,
		VAT_DST_ACCT_TYPE,
		VAT_ENTITY,
		VAT_EXCPTN_CERTIF,
		VAT_EXCPTN_TYPE,
		VAT_RECALC_FLG,
		VAT_RGSTRN_BUYER,
		VAT_ROUND_RULE,
		VAT_TREATMENT,
		VAT_TREATMENT_GRP,
		VAT_TXN_TYPE_CD,
		VAT_SERVICE_TYPE,
		VAT_SVC_SUPPLY_FLG,
		TAX_CD_VAT,
		PROCESS_INSTANCE,
		DATETIME_ADDED,
		LASTUPDDTTM,
		LAST_MAINT_OPRID
			)
	VALUES(
			'TRUS1' , --BUSINESS_UNIT
			'0004346624', --ORDER_NO
			1, --ORDER_INT_LINE_NO
			@itemId, --PRODUCT_ID
			'S', --PROD_ID_SRC
			@itemId, --PROD_ID_ENTERED
			1, --ADDRESS_SEQ_NUM
			'', --ADDR_OVRD_LEVEL
			'', --AERP
			'N', --ALLOW_OVERPICK_FLG
			'Y', --BCKORDR_CNCL_FLAG
			'', --CSD_BENEFIT_ID
			'', --PRICE_PROGRAM
			'2014-04-10 08:59:07.543', --CANCEL_DATE
			'UPS', --CARRIER_ID
			'', --CARRIER_ID_EXP
			'N', --CCI_REQ_EXP
			'', --CONFIG_CODE
			'N', --COO_REQ_EXP
			'USA', --COUNTRY_LOC_BUYER
			'USA', --COUNTRY_LOC_SELLER
			'USA', --COUNTRY_SHIP_FROM
			'USA', --COUNTRY_SHIP_TO
			'', --COUNTRY_VAT_BILLFR
			'', --COUNTRY_VAT_BILLTO
			'USA', --COUNTRY_VAT_PERFRM
			'', --COUNTRY_VAT_SUPPLY
			'', --CP_TEMPLATE_ID
			'USD', --CURRENCY_CD
			'USD', --CURRENCY_CD_BASE
			0.00000, --CUST_BILL_BACK_ALL
			0.00000, --CUST_BBACK_ALL_BSE
			0.00000, --CUST_NET_PRICE
			0.00000, --CUST_NET_PRC_BASE
			0.00000, --CUST_OFF_INV_DISC
			0.00000, --CUST_OFF_INV_BASE
			0.00000, --CUST_PO_PRICE
			0.00000, --CUST_PO_PRC_BASE
			@itemId, --CUSTOMER_ITEM_NBR
			'22360499', --CUSTOMER_PO
			1, --CUSTOMER_PO_LINE
			'N', --DROP_SHIP_FLAG
			'N', --EXPORT
			'', --EXPORT_LIC_REQ
			'', --EXPORT_LIC_TYPE
			'', --EXPORT_LIC_APPL
			NULL, --EXPORT_APPL_DT
			'', --EXPORT_LIC_REC
			NULL, --EXPORT_REC_DT
			'', --EXPORT_LIC_NBR
			NULL, --EXPORT_LIC_EXPIRE
			0.00, --EXPORT_LIC_VALUE
			0, --EXPORT_LIC_QTY
			'PREPAID', --FREIGHT_TERMS
			'', --EXS_TAX_TXN_TYPE
			'', --FREIGHT_TERMS_EXP
			'', --IMPORT_LIC_REQ
			'', --IMPORT_LIC_APPL
			NULL, --IMPORT_APPL_DT
			'', --IMPORT_LIC_REC
			NULL, --IMPORT_REC_DT
			'', --IMPORT_CERT_NBR
			'', --IMPORT_LIC_EXP
			'', --IST_TXN_FLG
			@orderStatus, --ORD_LINE_STATUS
			0, --LIST_PRICE
			0, --LIST_PRICE_BASE
			0, --LIST_PRICE_ORIG
			0, --LIST_PRICEORIG_BSE
			'', --LOAD_ID
			0, --MAX_PICK_TOLERANCE
			'', --NAFTA_REQ_EXP
			'', --ORDER_GRP
			'', --ORD_LINE_TAG
			'', --PAYMENT_METHOD
			'', --PHYSICAL_NATURE
			'', --PYMNT_TERMS_CD
			0, --PRICE
			0, --PRICE_BASE
			0, --PRICE_ORIG
			0, --PRICE_ORIG_BASE
			'', --PRICE_PROTECTED
			'', --PRODUCT_ID_ORIG
			0, --QTY_ORDERED
			0, --QTY_ORDERED_ORIG
			'', --REASON_CD
			'', --REPLACEMENT_FLG
			'2014-04-15 00:00:00.000', --REQ_ARRIVAL_DTTM
			'2014-04-15 00:00:00.000', --REQ_SHIP_DTTM
			'2014-04-15 00:00:00.000', --SCHED_ARRV_DTTM
			'2014-04-15 00:00:00.000', --SCHED_SHIP_DTTM
			'', --SED_REQ_EXP
			'', --SHIP_FROM_BU
			'', --SHIP_PARTIAL_FLAG
			'', --SHIP_PRIOR_FLAG
			'', --SHIP_PRIORITY_ID
			'', --SHIP_PRIORITY_EXP
			'', --SHIP_TO_CUST_ID
			'', --SHIP_TYPE_ID
			'', --SHIP_TYPE_ID_EXP
			'', --STATE_LOC_BUYER
			'', --STATE_LOC_SELLER
			'', --STATE_SHIP_FROM
			'', --STATE_SHIP_TO
			'', --STATE_VAT_DEFAULT
			'', --STATE_VAT_PERFRM
			0, --STD_DISCOUNT
			'', --STORE_NUMBER
			'', --TAX_CD
			'', --TAX_CUST_GROUP
			0, --TRNSPT_LEAD_DAYS
			0, --TRNSPT_LEAD_HOURS
			0, --TRNSPT_LEAD_MIN
			0, --UNIT_COST
			'', --UNIT_OF_MEASURE
			'', --UOM_ORIG
			'', --CNTRCT_ID
			0, --CNTRCT_LINE_NBR
			0, --CNTRCT_SCHED_NBR
			'', --VAT_APPLICABILITY
			'', --VAT_CALC_GROSS_NET
			'', --VAT_CNTRY_SUBD_FLG
			'', --VAT_DCLRTN_POINT
			'', --VAT_DFLT_DONE_FLG
			'', --VAT_DST_ACCT_TYPE
			'', --VAT_ENTITY
			'', --VAT_EXCPTN_CERTIF
			'', --VAT_EXCPTN_TYPE
			'', --VAT_RECALC_FLG
			'', --VAT_RGSTRN_BUYER
			'', --VAT_ROUND_RULE
			'', --VAT_TREATMENT
			'', --VAT_TREATMENT_GRP
			'', --VAT_TXN_TYPE_CD
			'', --VAT_SERVICE_TYPE
			'', --VAT_SVC_SUPPLY_FLG
			'', --TAX_CD_VAT
			0, --PROCESS_INSTANCE
			'2014-04-15 00:00:00.000', --DATETIME_ADDED
			'2014-04-15 00:00:00.000', --LASTUPDDTTM
			''  --LAST_MAINT_OPRID
			)


END
GO

/*
sp_help PS_ORD_LINE
*/