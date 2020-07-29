<template>
  <div>
    <span class="bg">
      <v-app>
        <v-app-bar app color="white" src="https://picsum.photos/1920/1080?random" dark>
          <v-app-bar-nav-icon @click="drawer = true"></v-app-bar-nav-icon>

          <v-toolbar-title>Todoist</v-toolbar-title>
          <v-spacer></v-spacer>
          <v-btn icon>
            <v-icon>mdi-logout</v-icon>
          </v-btn>
        </v-app-bar>
        <v-navigation-drawer v-model="drawer" absolute temporary>
          <v-list nav dense>
            <v-list-item-group active-class="deep-white--text text--accent-4">
              <v-list-item>
                <v-list-item-icon>
                  <v-icon>mdi-note</v-icon>
                </v-list-item-icon>
                <v-list-item-title>Notes</v-list-item-title>
              </v-list-item>

              <v-list-item>
                <v-list-item-icon>
                  <v-icon>mdi-target</v-icon>
                </v-list-item-icon>
                <v-list-item-title>Targets</v-list-item-title>
              </v-list-item>
            </v-list-item-group>
          </v-list>
        </v-navigation-drawer>
        <v-main>
          <Board />
        </v-main>
      </v-app>
    </span>
  </div>
</template>

<script>
import Board from "./components/Board";
export default {
  name: "App",

  components: {
    Board: Board,
  },

  data: () => ({
    drawer: false,
  }),
};
</script>
<style scoped>
</style>
