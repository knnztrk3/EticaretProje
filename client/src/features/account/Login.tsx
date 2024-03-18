import Avatar from '@mui/material/Avatar';
import TextField from '@mui/material/TextField';
import Grid from '@mui/material/Grid';
import Box from '@mui/material/Box';
import LockOutlinedIcon from '@mui/icons-material/LockOutlined';
import Typography from '@mui/material/Typography';
import Container from '@mui/material/Container';
import { Paper } from '@mui/material';
import { Link, useLocation, useNavigate } from 'react-router-dom';
import { FieldValues, useForm } from 'react-hook-form';
import { LoadingButton } from '@mui/lab';
import { useAppDispatch } from '../../app/store/configureStore';
import { signInUser } from './accountSlice';

function Copyright(props: any) {
  return (
    <Typography variant="body2" color="text.secondary" align="center" {...props}>
      {'Tüm hakları saklıdır © '}
      <Link color="inherit" to="/">
        bakbi.com
      </Link>{' '}
      {new Date().getFullYear()}
      {'.'}
    </Typography>
  );
}

export default function Login() {
  const navigate = useNavigate();
  const location = useLocation();
  const dispatch = useAppDispatch();
  const {register, handleSubmit, formState: {isSubmitting, errors, isValid}} = useForm({
    mode: 'onTouched'
  }) 

  async function submitForm(data: FieldValues) {
    try {
      await dispatch(signInUser(data));
      navigate(location.state?.from || '/catalog');
    } catch (error) {
      console.log(error);
    }
  }
 
  return (
    <Container component={Paper} maxWidth="sm" sx={{display: 'flex', flexDirection: 'column', alignItems: 'center', p: 4}}>
        <Avatar sx={{ m: 1, bgcolor: 'secondary.main' }}>
          <LockOutlinedIcon />
        </Avatar>
        <Typography component="h1" variant="h5">
          Giriş Yap
        </Typography>
        <Box component="form" onSubmit={handleSubmit(submitForm)} noValidate sx={{ mt: 1 }}>
          <TextField
            margin="normal"
            fullWidth
            label="Kullanıcı Adı"
            autoFocus
            {...register('username', { 
              required: 'Kullanıcı adınızı giriniz.'
            })}
            error={!!errors.username} // -> varsa true döndürücek '!!' sayesinde
            helperText={errors?.username?.message as string}
          />
          <TextField
            margin="normal"
            fullWidth
            label="Şifre"
            type="password"
            {...register('password', { 
              required: 'Şifrenizi giriniz.'
            })}
            error={!!errors.password} // -> varsa true döndürücek '!!' sayesinde
            helperText={errors?.password?.message as string}
          />
          <LoadingButton
            loading={isSubmitting}
            disabled={!isValid}
            type="submit"
            fullWidth
            variant="contained"
            sx={{ mt: 3, mb: 2 }}
          >
            Giriş Yap
          </LoadingButton>
          <Grid container>
          <Grid item xs>
            {/*  */}
          </Grid>
            <Grid item>
              <Link to="/register" >
                {"Üye değil misin? Üye Ol"}
              </Link>
            </Grid>
          </Grid>
        </Box>
        <Copyright sx={{ mt: 8, mb: 4 }} />
    </Container>
  );
}