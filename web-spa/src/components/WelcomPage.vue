<template>
  <v-app>
    <div class="overflow-hidden">
      <v-app-bar color="white">

        <v-toolbar-title>Todoist</v-toolbar-title>

        <v-spacer></v-spacer>

        <v-btn @click="handleLogin">Sign in</v-btn>
      </v-app-bar>
      <v-main>
        <v-parallax src="https://cdn.vuetifyjs.com/images/parallax/material.jpg">
          <v-row align="center" justify="center">
            <v-col class="text-center" cols="12">
              <h1 class="display-1 font-weight-thin mb-4">"Thật không thể tin được, chính chúng tôi cũng không thể tin là mình có thể làm được như vậy</h1>
              <h4 class="subheading"> - Quảng Nổ -</h4>
            </v-col>
          </v-row>
        </v-parallax>
        <br />
        <v-card elevation="24" max-width="75%" class="mx-auto">
          <v-carousel
            :continuous="false"
            :cycle="cycle"
            :show-arrows="false"
            hide-delimiter-background
            delimiter-icon="mdi-minus"
            height="300"
          >
            <v-carousel-item v-for="(slide, i) in slides" :key="i">
              <v-sheet :color="colors[i]" height="100%" tile>
                <v-row class="fill-height" align="center" justify="center">
                  <div class="display-3">{{ slide }} Slide</div>
                </v-row>
              </v-sheet>
            </v-carousel-item>
          </v-carousel>
        </v-card>
        <br />
        <v-footer dark padless>
          <v-card flat tile class="indigo lighten-1 white--text text-center">
            <v-card-text>
              <v-btn v-for="icon in icons" :key="icon" class="mx-4 white--text" icon>
                <v-icon size="24px">{{ icon }}</v-icon>
              </v-btn>
            </v-card-text>

            <v-card-text
              class="white--text pt-0"
            >Phasellus feugiat arcu sapien, et iaculis ipsum elementum sit amet. Mauris cursus commodo interdum. Praesent ut risus eget metus luctus accumsan id ultrices nunc. Sed at orci sed massa consectetur dignissim a sit amet dui. Duis commodo vitae velit et faucibus. Morbi vehicula lacinia malesuada. Nulla placerat augue vel ipsum ultrices, cursus iaculis dui sollicitudin. Vestibulum eu ipsum vel diam elementum tempor vel ut orci. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus.</v-card-text>

            <v-divider></v-divider>

            <v-card-text class="white--text">
              {{ new Date().getFullYear() }} —
              <strong>Vuetify</strong>
            </v-card-text>
          </v-card>
        </v-footer>
      </v-main>
    </div>
  </v-app>
</template>
<script>
import auth from "./../common/AuthService";
export default {
  name: "WelcomPage",
  data() {
    return {
      colors: [
        "green",
        "secondary",
        "yellow darken-4",
        "red lighten-2",
        "orange darken-1",
      ],
      cycle: false,
      slides: ["First", "Second", "Third", "Fourth", "Fifth"],
    };
  },
  components: {},
  methods: {
    handleLogin() {
      auth.signinRedirect();
    },
  },
};
</script>