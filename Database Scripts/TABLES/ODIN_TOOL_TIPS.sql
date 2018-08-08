SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[ODIN_TOOL_TIPS]
(  
    [NAME] VARCHAR(255),
	[VALUE] VARCHAR(MAX)
    PRIMARY KEY (NAME)
)
GO

SET ANSI_PADDING OFF
GO

/*
sp_help ODIN_TOOL_TIPS
SELECT * FROM ODIN_TOOL_TIPS

INSERT INTO [ODIN_TOOL_TIPS] VALUES ('BillOfMaterials', 'Bill of Materials: If this item contains BOM components this field must be a comma-delimited list of the BOM components. Item Ids used as BOM components must already exist in peoplesoft.')
INSERT INTO [ODIN_TOOL_TIPS] VALUES ('AccountingGroup', 'Accounting Group')
INSERT INTO [ODIN_TOOL_TIPS] VALUES ('CasepackDimension', 'Casepack')
INSERT INTO [ODIN_TOOL_TIPS] VALUES ('CasepackQty', 'Casepack Quantity')
INSERT INTO [ODIN_TOOL_TIPS] VALUES ('CasepackUpc', 'Casepack UPC')
INSERT INTO [ODIN_TOOL_TIPS] VALUES ('Category', 'The category this item will be assigned to on trendsinternational.com')
INSERT INTO [ODIN_TOOL_TIPS] VALUES ('Color', 'Color')
INSERT INTO [ODIN_TOOL_TIPS] VALUES ('Copyright', 'The copyright text that will appear for this item on trendsinternational.com')
INSERT INTO [ODIN_TOOL_TIPS] VALUES ('CostProfileGroup', 'Cost Profile Group')
INSERT INTO [ODIN_TOOL_TIPS] VALUES ('CountryOfOrigin', 'Item''s country of origin')
INSERT INTO [ODIN_TOOL_TIPS] VALUES ('DefaultActualCost', 'Default Actual Cost')
INSERT INTO [ODIN_TOOL_TIPS] VALUES ('Description', 'Description')
INSERT INTO [ODIN_TOOL_TIPS] VALUES ('DirectImport', 'Direct Import')
INSERT INTO [ODIN_TOOL_TIPS] VALUES ('Duty', 'Duty')
INSERT INTO [ODIN_TOOL_TIPS] VALUES ('Ean', 'Ean')
INSERT INTO [ODIN_TOOL_TIPS] VALUES ('Ecommerce_AsinToolTip', 'ASIN Tool Tip')
INSERT INTO [ODIN_TOOL_TIPS] VALUES ('Ecommerce_BulletToolTip', 'Bullet point that will be shown in the eCommerce retailer''s site')
INSERT INTO [ODIN_TOOL_TIPS] VALUES ('Ecommerce_ComponentsToolTip', 'The list of the components of this item')
INSERT INTO [ODIN_TOOL_TIPS] VALUES ('Ecommerce_CostToolTip', 'The price that Trends charges Amazon for this item')
INSERT INTO [ODIN_TOOL_TIPS] VALUES ('Ecommerce_ExternalIDToolTip', 'Identifer based on the external ID type (i.e. UPC, EAN, etc.)')
INSERT INTO [ODIN_TOOL_TIPS] VALUES ('Ecommerce_ExternalIdTypeToolTip', 'Type of identifier used to identity product with eCommerce retailers')
INSERT INTO [ODIN_TOOL_TIPS] VALUES ('Ecommerce_ImagePathToolTip', 'Fully-qualified file name (including server path) of this item''s image')
INSERT INTO [ODIN_TOOL_TIPS] VALUES ('Ecommerce_ItemHeightToolTip', 'Item''s height (in inches)')
INSERT INTO [ODIN_TOOL_TIPS] VALUES ('Ecommerce_ItemLengthToolTip', 'Item''s length (in inches)')
INSERT INTO [ODIN_TOOL_TIPS] VALUES ('Ecommerce_ItemNameToolTip', 'Ecommerce_ItemNameToolTip')
INSERT INTO [ODIN_TOOL_TIPS] VALUES ('Ecommerce_ItemWeightToolTip', 'Item''s weight (in pounds)')
INSERT INTO [ODIN_TOOL_TIPS] VALUES ('Ecommerce_ItemWidthToolTip', 'Item''s width (in inches)')
INSERT INTO [ODIN_TOOL_TIPS] VALUES ('Ecommerce_ManufacturerNameToolTip', 'Manufacturer name')
INSERT INTO [ODIN_TOOL_TIPS] VALUES ('Ecommerce_ModelNameToolTip', 'Model name')
INSERT INTO [ODIN_TOOL_TIPS] VALUES ('Ecommerce_MsrpToolTip', 'Amazon''s MSRP')
INSERT INTO [ODIN_TOOL_TIPS] VALUES ('Ecommerce_PackageHeightToolTip', 'Item''s packaged height (in inches)')
INSERT INTO [ODIN_TOOL_TIPS] VALUES ('Ecommerce_PackageLengthToolTip', 'Item''s packaged length (in inches)')
INSERT INTO [ODIN_TOOL_TIPS] VALUES ('Ecommerce_PackageWeightToolTip', 'Item''s packaged weight (in pounds)')
INSERT INTO [ODIN_TOOL_TIPS] VALUES ('Ecommerce_PackageWidthToolTip', 'Item''s packaged width (in inches)')
INSERT INTO [ODIN_TOOL_TIPS] VALUES ('Ecommerce_ProductCategoryToolTip', 'Product category')
INSERT INTO [ODIN_TOOL_TIPS] VALUES ('Ecommerce_ProductDescriptionToolTip', 'Full description that will be shown on the eCommerce retailer''s site')
INSERT INTO [ODIN_TOOL_TIPS] VALUES ('Ecommerce_ProductSubcategoryToolTip', 'Product subcategory')
INSERT INTO [ODIN_TOOL_TIPS] VALUES ('Ecommerce_SearchTermsToolTip', 'Semicolon-delimited list of search terms')
INSERT INTO [ODIN_TOOL_TIPS] VALUES ('Ecommerce_SizeToolTip', 'Item size as a string (ex. 12'' x 12'')')
INSERT INTO [ODIN_TOOL_TIPS] VALUES ('Ecommerce_UpcToolTip', 'If this item is being sold to retailers (such as Walmart) who sell the item in-store and online and Trends charges the retailer a different price for each, this is the UPC of the online version of the item')
INSERT INTO [ODIN_TOOL_TIPS] VALUES ('Gpc', 'GPC')
INSERT INTO [ODIN_TOOL_TIPS] VALUES ('Height', 'Item''s Height')
INSERT INTO [ODIN_TOOL_TIPS] VALUES ('ImagePath', 'Image Path for trendsinterantional.com')
INSERT INTO [ODIN_TOOL_TIPS] VALUES ('InnerpackDimension', 'Innerpack')
INSERT INTO [ODIN_TOOL_TIPS] VALUES ('InnerpackQuantity', 'Innerpack Quantity')
INSERT INTO [ODIN_TOOL_TIPS] VALUES ('InnerpackUpc', 'Innerpack UPC')
INSERT INTO [ODIN_TOOL_TIPS] VALUES ('InStockDate', 'The date in which this item will be visible on trendsinternational.com')
INSERT INTO [ODIN_TOOL_TIPS] VALUES ('Isbn', 'ISBN')
INSERT INTO [ODIN_TOOL_TIPS] VALUES ('ItemCategory', 'Item Category')
INSERT INTO [ODIN_TOOL_TIPS] VALUES ('ItemFamily', 'Item Family')
INSERT INTO [ODIN_TOOL_TIPS] VALUES ('ItemGroup', 'Item Group')
INSERT INTO [ODIN_TOOL_TIPS] VALUES ('ItemId', 'Item''s Unique ID (a.k.a. SKU, Product ID)')
INSERT INTO [ODIN_TOOL_TIPS] VALUES ('ItemKeywords', 'Keywords to lookup this item on trendsinternational.com')
INSERT INTO [ODIN_TOOL_TIPS] VALUES ('Language', 'Item''s language. (Accepted values: ENG, SPA, FRA)')
INSERT INTO [ODIN_TOOL_TIPS] VALUES ('Length', 'Item''s Length')
INSERT INTO [ODIN_TOOL_TIPS] VALUES ('License', 'The license this item will be assigned to on trendsinternational.com')
INSERT INTO [ODIN_TOOL_TIPS] VALUES ('LicenseBeginDate', 'License Begin Date')
INSERT INTO [ODIN_TOOL_TIPS] VALUES ('ListPrice', 'List Price')
INSERT INTO [ODIN_TOOL_TIPS] VALUES ('MetaDescription', 'The description that will appear under the item name on trendsinternational.com')
INSERT INTO [ODIN_TOOL_TIPS] VALUES ('MfgSource', 'MFG Source')
INSERT INTO [ODIN_TOOL_TIPS] VALUES ('Msrp', 'MSRP')
INSERT INTO [ODIN_TOOL_TIPS] VALUES ('PricingGroup', 'Pricing Group')
INSERT INTO [ODIN_TOOL_TIPS] VALUES ('PrintOnDemand', 'Print On Demand')
INSERT INTO [ODIN_TOOL_TIPS] VALUES ('ProductFormat', 'Product Format')
INSERT INTO [ODIN_TOOL_TIPS] VALUES ('ProductGroup', 'Product Group')
INSERT INTO [ODIN_TOOL_TIPS] VALUES ('ProductIdTranslation', 'Product Id Translation: If this item is a bundle, this field must be a comma-delimited list of the components of the bundle')
INSERT INTO [ODIN_TOOL_TIPS] VALUES ('ProductLine', 'Product Line')
INSERT INTO [ODIN_TOOL_TIPS] VALUES ('ProductQty', 'Product Qunatity')
INSERT INTO [ODIN_TOOL_TIPS] VALUES ('ProductType', 'Product Type')
INSERT INTO [ODIN_TOOL_TIPS] VALUES ('Property', 'The Property (or second tier License) that this item will be assigned to on trendsinternational.com')
INSERT INTO [ODIN_TOOL_TIPS] VALUES ('PsStatus', 'PS Status')
INSERT INTO [ODIN_TOOL_TIPS] VALUES ('SatCode', 'Item''s SAT Code')
INSERT INTO [ODIN_TOOL_TIPS] VALUES ('SellOnAllPosters', 'Set to Y if this item is being sold on AllPosters.com or Art.com.')
INSERT INTO [ODIN_TOOL_TIPS] VALUES ('SellOnAmazon', 'Set to Y if this item is being sold on Amazon.com.')
INSERT INTO [ODIN_TOOL_TIPS] VALUES ('SellOnFanatics', 'Set to Y if this item is being sold on Fanatics.com')
INSERT INTO [ODIN_TOOL_TIPS] VALUES ('SellOnHayneedle', 'Set to Y if this item is being sold on Hayneedle.com')
INSERT INTO [ODIN_TOOL_TIPS] VALUES ('SellOnTarget', 'Set to Y if this item is being sold on Target.com')
INSERT INTO [ODIN_TOOL_TIPS] VALUES ('SellOnTrends', 'Set to Y if this item is being sold on TrendsInternational.com.')
INSERT INTO [ODIN_TOOL_TIPS] VALUES ('SellOnWalmart', 'Set to Y if this item is being sold on Walmart.com')
INSERT INTO [ODIN_TOOL_TIPS] VALUES ('ShortDescription', 'The description that will appear on the item''s page on trendsinternational.com')
INSERT INTO [ODIN_TOOL_TIPS] VALUES ('Size', 'A text value that will display on this item''s page on trendsinternational.com')
INSERT INTO [ODIN_TOOL_TIPS] VALUES ('StandardCost', 'Standard Cost')
INSERT INTO [ODIN_TOOL_TIPS] VALUES ('StatsCode', 'Stats Code')
INSERT INTO [ODIN_TOOL_TIPS] VALUES ('TariffCode', 'Tariff Code')
INSERT INTO [ODIN_TOOL_TIPS] VALUES ('TemplateId', 'Template''s Unique Name')
INSERT INTO [ODIN_TOOL_TIPS] VALUES ('Territory', 'Territory')
INSERT INTO [ODIN_TOOL_TIPS] VALUES ('Title', 'Name of this item that will appear on trendsinternational.com')
INSERT INTO [ODIN_TOOL_TIPS] VALUES ('Udex', 'Udex')
INSERT INTO [ODIN_TOOL_TIPS] VALUES ('Upc', 'Upc')
INSERT INTO [ODIN_TOOL_TIPS] VALUES ('Weight', 'Item''s Weight')
INSERT INTO [ODIN_TOOL_TIPS] VALUES ('Width', 'Item''s Width')

*/