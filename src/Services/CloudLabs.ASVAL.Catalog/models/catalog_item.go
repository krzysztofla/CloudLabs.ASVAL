package catalog

type CatalogItem struct {
	Id               int
	Name             string
	Description      string
	Price            int
	PictureFileName  string
	PictureUri       string
	CatalogTypeId    int
	CatalogType      CatalogType
	CatalogBrand     CatalogBrand
	AvailableStock   int
	RestockTreshold  int
	MaxStockTreshold int
	OnReorder        bool
}
