import { Avatar, Button, Card, CardActions, CardContent, CardHeader, CardMedia, Typography } from "@mui/material";
import { Product } from "../../app/models/product";
import { Link } from "react-router-dom";
import { LoadingButton } from "@mui/lab";
import { currencyFormat } from "../../app/util/util";
import { useAppDispatch, useAppSelector } from "../../app/store/configureStore";
import { addBasketItemAsync } from "../basket/basketSlice";
import { grey, orange } from "@mui/material/colors";

interface Props {
    product: Product;
}

export default function ProductCard({product}: Props){
  const {status} = useAppSelector(state => state.basket);
  const dispatch = useAppDispatch();


    return (
        <Card>
            <CardHeader 
                avatar={
                    <Avatar sx={{bgcolor: orange[400]}}>
                        {product.name.charAt(0).toUpperCase()}
                    </Avatar>
                }
                title={product.name}
                titleTypographyProps={{
                    sx: {
                      fontWeight: 'bold', 
                      color: grey[900]
                    }
                }}
            />

      <CardMedia
        sx={{ height: 270, backgroundSize: 'contain'}}
        image={product.pictureUrl}
        title={product.name}
      />
      <CardContent>
        <Typography gutterBottom sx={{color: orange[900]}} variant="h5">
          {currencyFormat(product.price)}
        </Typography>
        <Typography variant="body2" color="text.secondary">
          {product.brand} / {product.type}
        </Typography>
      </CardContent>
      <CardActions>
        <LoadingButton 
          loading={status.includes('pendingAddItem' + product.id)} 
          onClick={() => dispatch(addBasketItemAsync({productId: product.id}))} 
          size="small">Sepete Ekle</LoadingButton>
        <Button component={Link} to={`/catalog/${product.id}`} size="small">Görüntüle</Button>
      </CardActions>
    </Card>
    )
}