import { ShoppingCart } from "@mui/icons-material";
import { AppBar, Badge, Box, IconButton, List, ListItem, Toolbar, Typography } from "@mui/material";
import { grey, orange } from '@mui/material/colors';
import { Link, NavLink } from "react-router-dom";
import { useAppSelector } from "../store/configureStore";
import SignedInMenu from "./SignedInMenu";

const midLinks = [
    {title: 'anasayfa', path: '/'},
    {title: 'ürünler', path: '/catalog'},
    {title: 'hakkimizda', path: '/hakkimizda'},
    {title: 'iletisim', path: '/iletisim'},
    
    // {title: 'test', path: '/about'},
    // {title: 'redux', path: '/contact'},
]

const rightLinks = [
    {title: 'giris', path: '/login'},
    {title: 'kayıt', path: '/register'},
]

const navStyles = {
    color: 'inherit', 
    textDecoration: 'none',
    typography: 'p',
    '&:hover': {
        color: grey[900]
    },
    '&.active': {
        color: grey[900],
    }
}

export default function Header(){
    const {basket} = useAppSelector(state => state.basket);
    const {user} = useAppSelector(state => state.account);
    const itemCount = basket?.items.reduce((sum, item) => sum + item.quantity, 0); 

    return(
        <AppBar position='static' sx={{bgcolor: orange[400], mb: 4}}>
            <Toolbar sx={{display: 'flex', justifyContent: 'space-between', alignItems: 'center'}}>
                <Box display='flex' alignItems='center'>
                    <Typography variant='h6' component={NavLink} 
                        to='/'
                        sx={navStyles}
                    >
                        <img src="logo.png" alt="resim-bulunamadi" />
                    </Typography>
                </Box>
                

                <List sx={{display: 'flex'}}>
                    {midLinks.map(({title, path}) => (
                        <ListItem
                           component={NavLink}
                           to={path} 
                           key={path}
                           sx={{color: grey[900]}}
                        >
                            {title.toUpperCase()}
                        </ListItem>
                    ))}
                </List>

                <Box display='flex' alignItems='center'>
                    <IconButton component={Link} to='/basket' size='large' edge='start' color='inherit' sx={{mr: 2}}>
                            <Badge badgeContent={itemCount} sx={{color: grey[50]}}>
                                <ShoppingCart />
                            </Badge>
                    </IconButton>  
                    {user ? (
                        <SignedInMenu />
                    ) : (
                    <List sx={{display: 'flex'}}>
                        {rightLinks.map(({title, path}) => (
                            <ListItem
                            component={NavLink}
                            to={path} 
                            key={path}
                            sx={navStyles}
                            >
                                {title.toUpperCase()}
                            </ListItem>
                        ))}
                    </List>
                    )}
                    
                </Box>
            </Toolbar>
        </AppBar>
    )
}