import { Button, Container, Divider, Paper, Typography } from "@mui/material";
import { Link } from "react-router-dom";

export default function NotFound(){
    return (
        <Container component={Paper} sx={{height: 400}}>
            <Typography gutterBottom variant='h3'>Oops - Sanırım kayboldunuz. Aradığınızı bulamadık. Lütfen başka bir anahtar kelime deneyin veya daha sonra tekrar kontrol edin.</Typography>
            <Divider />
            <Button fullWidth component={Link} to='/catalog'>Anasayfaya geri dön</Button>
        </Container>
    )
}