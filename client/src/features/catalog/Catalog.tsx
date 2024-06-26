import LoadingComponent from "../../app/layout/LoadingComponent";
import { useAppDispatch, useAppSelector } from "../../app/store/configureStore";
import ProductList from "./ProductList";
import { useEffect } from "react";
import { fetchFilters, fetchProductsAsync, productSelectors, setPageNumber, setProductParams } from "./catalogSlice";
import { Grid, Paper } from "@mui/material";
import ProductSearch from "./ProductSearch";
import RadioButtonGroup from "../../app/components/RadioButtonGroup";
import CheckboxButtons from "../../app/components/CheckboxButtons";
import AppPagination from "../../app/components/AppPagination";

const sortOptions = [
  {value: 'name', label: 'Ürün Adına Göre (A>Z)'},
  {value: 'priceDesc', label: 'En yüksek fiyat'},
  {value: 'price', label: 'En düşük fiyat'},
]

export default function Catalog() {
    const products = useAppSelector(productSelectors.selectAll);// tum ürün listesini döndürür
    const {productsLoaded, filtersLoaded, brands, types, productParams, metaData} = useAppSelector(state => state.catalog);
    const dispatch = useAppDispatch();

  useEffect(() => {
      if (!productsLoaded) dispatch(fetchProductsAsync());
  }, [productsLoaded, dispatch])

  useEffect(() => {
    if (!filtersLoaded) dispatch(fetchFilters());
  }, [dispatch, filtersLoaded])

  if (!filtersLoaded) return <LoadingComponent message='Ürünler yükleniyor...'/>

    return (
        <Grid container columnSpacing={4}>
          <Grid item xs={3}>
            <Paper sx={{mb: 2}}>
              <ProductSearch />
            </Paper>
            
            <Paper sx={{mb: 2, p: 2}}>
              <RadioButtonGroup 
                selectedValue={productParams.orderBy}
                options={sortOptions}
                onChange={(e) => dispatch(setProductParams({orderBy: e.target.value}))}
              />
            </Paper>

            <Paper sx={{mb: 2, p: 2}}>
            <i className="fa-solid fa-list"> Markalar</i>
              <CheckboxButtons 
                items={brands}
                checked={productParams.brands}
                onChange={(items: string[]) => dispatch(setProductParams({brands: items}))} />
            </Paper>

            <Paper sx={{mb: 2, p: 2}}>
              <i className="fa-solid fa-list"> Kategoriler</i>
            <CheckboxButtons 
                items={types}
                checked={productParams.types}
                onChange={(items: string[]) => dispatch(setProductParams({types: items}))} />
            </Paper>

          </Grid>
          <Grid item xs={9}>
           <ProductList products={products}/>
          </Grid>
          <Grid item xs={3} />
          <Grid item xs={9} sx={{mb: 2}}>
            {metaData && //metaData dolu ise sayfayı çağır
            <AppPagination
              metaData={metaData}
              onPageChange={(page: number) => dispatch(setPageNumber({pageNumber: page}))}
            />}
          </Grid>
        </Grid>
    )
}