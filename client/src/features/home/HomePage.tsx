import { ArrowRightOutlined } from '@ant-design/icons';
import { useEffect } from 'react';

import { Link } from 'react-router-dom';
import { fetchFilters, fetchProductsAsync, productSelectors } from '../catalog/catalogSlice';
import { useAppDispatch, useAppSelector } from '../../app/store/configureStore';
import LoadingComponent from '../../app/layout/LoadingComponent';
import { Grid } from '@mui/material';
import ProductList from '../catalog/ProductList';

const Home = () => {

    const products = useAppSelector(productSelectors.selectAll);// tum ürün listesini döndürür
    const {productsLoaded, filtersLoaded} = useAppSelector(state => state.catalog);
    const dispatch = useAppDispatch();

  useEffect(() => {
      if (!productsLoaded) dispatch(fetchProductsAsync());
  }, [productsLoaded, dispatch])

  useEffect(() => {
    if (!filtersLoaded) dispatch(fetchFilters());
  }, [dispatch, filtersLoaded])

  if (!filtersLoaded) return <LoadingComponent message='Sayfa yükleniyor...'/>

 
  return (
    <main className="content">
      <div className="home">
        <div className="banner">
          <div className="banner-desc">
            <h2 className="text-thin">
              Kampanyalı Ürünler
              <br/>
              Çok Özel Fiyatlarla!
            </h2>
            
            <p>
            Kadın giyim, Erkek giyim ve Çocuk giyim kategorilerinde en hesaplı fiyatlarla birbirinden şık elbiseler pantolonlar tişörtler ayakkabılar ve daha binlerce yeni sezon ürünü modamızbir de bulabilirsiniz. Türkiye’nin moda sitesi için hemen tıkla!
            </p>
            <br />
            <Link to="#" className="button">
              Shop Now &nbsp;
              <ArrowRightOutlined />
            </Link>
          </div>
          <div className="banner-img"><img src="/images/menu/banner-girl.png" alt="resim yok" /></div>
          
        </div>
        <br/>
        <hr />
        <div className="display">
          <div className="display-header">
            <h1>Yeni Gelenler</h1>
            <Grid container columnSpacing={4}>
          
            <Grid item xs={12}>
             <ProductList products={products}/>
            </Grid>
           
          </Grid>
            <Link to="/catalog">Tümünü Görüntüle</Link>

          </div>
        </div>
      </div>
    </main>
  );
};

export default Home;

