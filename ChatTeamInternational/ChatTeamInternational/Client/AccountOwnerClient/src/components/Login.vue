
  <template>
    <div class="page-header">
      <h1> Login page </h1>
    </div>

    <div class="loginForm">
      <div class="container">

        <div id="exTab3" class="container">
          <ul class="nav nav-pills">
            <li class="active">
              <a href="#1b" data-toggle="tab">Login</a>
            </li>
            <li>
              <a href="#2b" data-toggle="tab">Join</a>
            </li>
          </ul>

          <div class="tab-content clearfix" style="background-color:white">
            <div class="tab-pane active" id="1b">
              <input id="login" type="text" placeholder="login" #loginInput />
              <input id="password " type="text" placeholder="password" #passwordInput />
              <div style="display:block">
                <button (click)="loginUser(loginInput.value, passwordInput.value)">Login</button>
                <button>Cancel</button>
              </div>
            </div>
            <div class="tab-pane" id="2b">
              <input type="text" placeholder="login" #loginRegister />
              <input type="text" placeholder="password" #passwordRegister />
              <input type="text" placeholder="repeat password" #passwordRepeatRegister />
              <div style="display:block">
                <button v-on(click)="registerUser(loginRegister.value, passwordRegister.value, passwordRepeatRegister.value)">Register</button>
                <button>Cancel</button>
              </div>
            </div>
          </div>
        </div>

      </div>
      <div id="validation">{{reportMessage}}</div>
    </div>
  </template>

<script>
  export default {
    name: 'HelloWorld',
    data() {
      return {
        msg: 'Welcome to Your Vue.js App'
      }
    }
  }
  {
  function loginUser(name, pass) {    
    
    var User = new User(name, pass);
   
    this.dataService.post("Account/LoginByToken", user).subscribe((obj) => {
      this.isValid = (obj!=null)?true:false;
      localStorage.setItem('token', obj['access_token']);
      if (this.isValid) {

        this.reportMessage = "User is valid";

        this.goToItem(this.skype);
      }
      else { this.reportMessage = "User not found, register please"; }
    });   
  }

  function registerUser(name: string, pass: string, repeatPass: string) {
            
    if (pass != repeatPass) {
      this.reportMessage = "Your password incorrect";
      return;
    }
    else {
      var userOnRegistration: User = new User(name, pass);

      this.dataService.post('Account/Register', userOnRegistration).subscribe((data: boolean) => {
        this.isValid = data;
        if (this.isValid) {
          this.reportMessage = "User allready exist";
        }
        else { this.reportMessage = "You have been registered successfully"; }
      });
    }

  }

  reportHandler() {

  }

 

}

</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>

  h1, h2 {
    font-weight: normal;
  }

  ul {
    list-style-type: none;
    padding: 0;
  }

  li {
    display: inline-block;
    margin: 0 10px;
  }

  a {
    color: #42b983;
  }
</style>
