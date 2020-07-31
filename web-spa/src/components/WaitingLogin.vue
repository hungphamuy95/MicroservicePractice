<template>
  <v-app>
    <v-sheet class="px-3 pt-3 pb-3">
      <v-skeleton-loader class="mx-auto" max-width="1920" type="list-item-avatar-three-line"></v-skeleton-loader>
      <v-row dense>
        <v-col cols="3">
            <v-skeleton-loader class="mx-auto" type="card"></v-skeleton-loader>
            <v-skeleton-loader class="mx-auto" type="card"></v-skeleton-loader>
            <v-skeleton-loader class="mx-auto" type="card"></v-skeleton-loader>
        </v-col>
        <v-col cols="3">
            <v-skeleton-loader class="mx-auto" type="card"></v-skeleton-loader>
            <v-skeleton-loader class="mx-auto" type="card"></v-skeleton-loader>
            <v-skeleton-loader class="mx-auto" type="card"></v-skeleton-loader>
        </v-col>
        <v-col cols="3">
            <v-skeleton-loader class="mx-auto" type="card"></v-skeleton-loader>
            <v-skeleton-loader class="mx-auto" type="card"></v-skeleton-loader>
            <v-skeleton-loader class="mx-auto" type="card"></v-skeleton-loader>
        </v-col>
        <v-col cols="3">
        </v-col>
    </v-row>
    </v-sheet>
  </v-app>
</template>
<script>
import router from "./../router/index";
import oidc from "oidc-client";
export default {
  name: "WaitingLogin",
  data: () => ({}),
  mounted() {
    const mgr = new oidc.UserManager({
      userStore: new oidc.WebStorageStateStore(),
      response_mode: "query",
    });
    console.log("test");
    mgr
      .signinRedirectCallback()
      .then(() => {
        router.push("/board");
      })
      .catch((err) => console.log(err));
  },
};
</script>