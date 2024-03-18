import Avatar from '@mui/material/Avatar';
import TextField from '@mui/material/TextField';
import Grid from '@mui/material/Grid';
import Box from '@mui/material/Box';
import LockOutlinedIcon from '@mui/icons-material/LockOutlined';
import Typography from '@mui/material/Typography';
import Container from '@mui/material/Container';
import { Paper } from '@mui/material';
import { Link, useNavigate } from 'react-router-dom';
import { useForm } from 'react-hook-form';
import { LoadingButton } from '@mui/lab';
import agent from '../../app/api/agent';
import { toast } from 'react-toastify';

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

export default function Register() {
    const navigate = useNavigate();
    const {register, handleSubmit, setError, formState: {isSubmitting, errors, isValid}} = useForm({
        mode: 'onTouched'
    }) 

    function handleApiError(errors: any) {
        if (errors) {
            errors.forEach((error: string) => {
                if (error.includes('Password')) {
                    setError('password', {message: error})
                } else if (error.includes('Email')) {
                    setError('email', {message: error})
                } else if (error.includes('Username')) {
                    setError('username', {message: error})
                }
            });
        }
    }

  return (
    <Container component={Paper} maxWidth="sm" sx={{display: 'flex', flexDirection: 'column', alignItems: 'center', p: 4}}>
        <Avatar sx={{ m: 1, bgcolor: 'secondary.main' }}>
          <LockOutlinedIcon />
        </Avatar>
        <Typography component="h1" variant="h5">
          Üye Ol
        </Typography>
        <Box component="form" 
            onSubmit={handleSubmit((data) => 
                agent.Account.register(data)
                    .then(() => {
                        toast.success('Kaydınız başarılı - Giriş yapabilirsiniz');
                        navigate('/login')
                    })
                    .catch(error => handleApiError(error)))} 
            noValidate sx={{ mt: 1 }}>
          <TextField
            margin="normal"
            fullWidth
            label="Kullanıcı Adı"
            autoFocus
            {...register('username', { 
                required: 'Kullanıcı adı giriniz.'
            })}
            error={!!errors.username} // -> varsa true döndürücek '!!' sayesinde
            helperText={errors?.username?.message as string}
          />
          <TextField
            margin="normal"
            fullWidth
            label="E-posta"
            {...register('email', { 
                required: 'E-posta giriniz.',
                pattern: {
                    value: /^\w+[\w-.]*@\w+((-\w+)|(\w*))\.[a-z]{2,3}$/,
                    message: 'Lütfen geçerli bir e-posta adresi giriniz.'
                }
             })}
            error={!!errors.email} // -> varsa true döndürücek '!!' sayesinde
            helperText={errors?.email?.message as string}
          />
          <TextField
            margin="normal"
            fullWidth
            label="Şifre"
            type="password"
            {...register('password', { 
                required: 'Şifre giriniz.',
                pattern: {
                    value: /(?=^.{6,10}$)(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&amp;*()_+}{&quot;:;'?/&gt;.&lt;,])(?!.*\s).*$/,
                    message: 'Şifreniz en az 7 karakter ve en fazla 64 karakter olmalı, harf ve rakam içermelidir.'
                }
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
            Üye Ol
          </LoadingButton>
          <Grid container>
          <Grid item xs>
            {/*  */}
          </Grid>
            <Grid item>
              <Link to="/login" >
                {"Zaten üye misiniz? Giriş Yap"}
              </Link>
            </Grid>
          </Grid>
        </Box>
        <Copyright sx={{ mt: 8, mb: 4 }} />
    </Container>
  );
}