using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace LTK268
{
    public static class GameObjectExtension
    {
        //-----------
        // @destroy
        //-----------
        public static void destroy_go<T>(this T @this)
            where T : Component
        {
            @this.gameObject.destroy_self();
        }

        public static void destroy_game_obj_gracefully<T>(this T @this)
            where T : Component
        {
            if (@this && @this.gameObject)
            {
                @this.gameObject.destroy_self_gracefully();
            }
        }

        //---------
        // @layer
        //---------


        public static GameObject layer(this GameObject @this, int layer)
        {
            @this.layer = layer;
            return @this;
        }


        public static T layer<T>(this T @this, int layer)
            where T : Component
        {
            @this.gameObject.layer = layer;
            return @this;
        }


        public static GameObject layer(this GameObject @this, string layer_name)
        {
            @this.layer = LayerMask.NameToLayer(layer_name);
            return @this;
        }


        public static T layer<T>(this T @this, string layer_name)
            where T : Component
        {
            @this.gameObject.layer = LayerMask.NameToLayer(layer_name);
            return @this;
        }


        public static bool is_in_layer_mask(this GameObject @this, LayerMask layer_mask)
        {
            return LayerMaskUtility.is_in_layer_mask(@this, layer_mask);
        }


        public static bool is_in_layer_mask<T>(this T @this, LayerMask layer_mask)
            where T : Component
        {
            return LayerMaskUtility.is_in_layer_mask(@this.gameObject, layer_mask);
        }

        public static class LayerMaskUtility
        {
            public static bool is_in_layer_mask(int layer, LayerMask layerMask)
            {
                var obj_layer_mask = 1 << layer;
                return (layerMask.value & obj_layer_mask) == obj_layer_mask;
            }

            public static bool is_in_layer_mask(GameObject @this, LayerMask layer_mask)
            {
                // Shift according to the layer value to obtain the mask for operation
                var obj_layer_mask = 1 << @this.layer;
                return (layer_mask.value & obj_layer_mask) == obj_layer_mask;
            }
        }



        public static T get_or_add_component<T>(this GameObject @this)
            where T : Component
        {
            var comp = @this.gameObject.GetComponent<T>();
            return comp ? comp : @this.gameObject.AddComponent<T>();
        }


        public static T get_or_add_component<T>(this Component @this)
            where T : Component
        {
            return @this.gameObject.get_or_add_component<T>();
        }

        //--------
        // @show
        //--------
        public static GameObject active(this GameObject @this)
        {
            @this.SetActive(true);
            return @this;
        }

        public static T active<T>(this T @this)
            where T : Component
        {
            @this.gameObject.active();
            return @this;
        }

        //--------
        // @hide
        //--------
        public static GameObject deactive(this GameObject @this)
        {
            @this.SetActive(false);
            return @this;
        }

        public static T deactive<T>(this T @this)
            where T : Component
        {
            @this.gameObject.deactive();
            return @this;
        }

        //------------
        //-- general
        //------------
        public static GameObject name(this GameObject @this, string name)
        {
            @this.name = name;
            return @this;
        }

        public static GameObject dont_destroy_on_load(this GameObject @this)
        {
            GameObject.DontDestroyOnLoad(@this);
            return @this;
        }

        public static void destroy_immediate(this GameObject @this)
        {
            GameObject.DestroyImmediate(@this);
        }

        //----------------------------------------
        //other GameObject
        public static GameObject find_go(this GameObject @this, string name)
        {
            return @this.transform.Find(name).gameObject;
        }

        public static T child<T>(this GameObject @this, string name)
            where T : Component
        {
            return @this.transform.child<T>(name);
        }

        public static Vector3 get_pos_in_screen_space(this GameObject @this)
        {
            return Camera.main.WorldToScreenPoint(@this.transform.position);
        }

        public static Vector3 screen_to_world_pos(this GameObject @this)
        {
            return Camera.main.ScreenToWorldPoint(@this.transform.position);
        }

        //-------------
        // @mesh size
        //-------------

        public static Vector3 msize<T>(this T @this)
            where T : Component
        {
            return @this.gameObject.msize();
        }

        public static Vector3 msize(this GameObject @this)
        {
            // Vector3 target_size = Vector3.one * 10.0f;
            // Mesh m = @this.GetComponent<MeshFilter>().sharedMesh;
            // Bounds mesh_bounds = m.bounds;
            // Vector3 mesh_size = mesh_bounds.size;
            Vector3 mesh_size = @this.GetComponent<Renderer>().bounds.size;
            return mesh_size;
        }

        //// set-size, setsize, set size
        //need object has mesh or sprite-renderer component
        public static float msize_x(this GameObject @this)
        {
            return @this.msize().x;
        }

        public static void msize_x(this GameObject @this, float new_size_x)
        {
            float cur_size_x = @this.GetComponent<Renderer>().bounds.size.x;
            float rescale_x = new_size_x * @this.transform.localScale.x / cur_size_x;
            @this.transform.localScale = new Vector3(
                rescale_x,
                @this.transform.localScale.y,
                @this.transform.localScale.z
            );
        }

        public static float msize_y(this GameObject @this)
        {
            return @this.msize().y;
        }

        public static void msize_y(this GameObject @this, float new_size_y)
        {
            float cur_size_y = @this.GetComponent<Renderer>().bounds.size.y;
            float rescale_y = new_size_y * @this.transform.localScale.y / cur_size_y;
            @this.transform.localScale = new Vector3(
                @this.transform.localScale.x,
                rescale_y,
                @this.transform.localScale.z
            );
        }

        public static float msize_z(this GameObject @this)
        {
            return @this.msize().z;
        }

        public static void msize_z(this GameObject @this, float new_size_z)
        {
            float cur_size_z = @this.GetComponent<Renderer>().bounds.size.z;
            float rescale_z = new_size_z * @this.transform.localScale.z / cur_size_z;
            @this.transform.localScale = new Vector3(
                @this.transform.localScale.x,
                @this.transform.localScale.y,
                rescale_z
            );
        }

        // public static void set_size(this GameObject @this, float newSize) {
        //   // float size = @this.GetComponent<Renderer>().bounds.size.z;
        //   // Vector3 rescale = @this.transform.localScale;
        //   // rescale.x = newSize * rescale.x / size;
        //   // rescale.y = newSize * rescale.y / size;
        //   // rescale.z = newSize * rescale.z / size;
        //   // @this.transform.localScale = rescale;
        // }



        //------------------------------
        //-- @access-common-components
        //------------------------------
        //audio-source
        public static AudioSource aus<T>(this T @this)
            where T : Component
        {
            return @this.GetComponent<AudioSource>();
        }

        public static AudioSource aus(this GameObject @this)
        {
            return @this.GetComponent<AudioSource>();
        }

        // box-collider
        public static BoxCollider bc<T>(this GameObject @this)
            where T : Component
        {
            return @this.GetComponent<BoxCollider>();
        }

        public static BoxCollider bc(this GameObject @this)
        {
            return @this.GetComponent<BoxCollider>();
        }

        // button
        public static Button btn<T>(this T @this)
            where T : Component
        {
            return @this.GetComponent<Button>();
        }

        public static Button btn(this GameObject @this)
        {
            return @this.GetComponent<Button>();
        }

        // particle-system
        public static ParticleSystem ps<T>(this T @this)
            where T : Component
        {
            return @this.GetComponent<ParticleSystem>();
        }

        public static ParticleSystem ps(this GameObject @this)
        {
            return @this.GetComponent<ParticleSystem>();
        }

        // particle-system-renderer
        public static ParticleSystemRenderer pr<T>(this T @this)
            where T : Component
        {
            return @this.GetComponent<ParticleSystemRenderer>();
        }

        public static ParticleSystemRenderer pr(this GameObject @this)
        {
            return @this.GetComponent<ParticleSystemRenderer>();
        }

        // mesh-renderer
        public static MeshRenderer mr<T>(this T @this)
            where T : Component
        {
            return @this.GetComponent<MeshRenderer>();
        }

        public static MeshFilter mf(this GameObject @this)
        {
            return @this.GetComponent<MeshFilter>();
        }

        // sprite-renderer
        public static SpriteRenderer sr<T>(this T @this)
            where T : Component
        {
            return @this.GetComponent<SpriteRenderer>();
        }

        public static SpriteRenderer sr(this GameObject @this)
        {
            return @this.GetComponent<SpriteRenderer>();
        }

        // renderer
        public static Renderer r<T>(this T @this)
            where T : Component
        {
            return @this.GetComponent<Renderer>();
        }

        public static Renderer r(this GameObject @this)
        {
            return @this.GetComponent<Renderer>();
        }
        //mesh
        public static MeshRenderer mf<T>(this T @this)
            where T : Component
        {
            return @this.GetComponent<MeshRenderer>();
        }

        //ui
        public static Canvas cv<T>(this T @this)
            where T : Component
        {
            return @this.GetComponent<Canvas>();
        }

        public static Canvas cv(this GameObject @this)
        {
            return @this.GetComponent<Canvas>();
        }

        //// rect-transform
        public static RectTransform rt<T>(this T @this)
            where T : Component
        {
            return @this.GetComponent<RectTransform>();
        }

        public static RectTransform rt(this GameObject @this)
        {
            return @this.GetComponent<RectTransform>();
        }

        //// Image
        public static Image img<T>(this T @this)
            where T : Component
        {
            return @this.GetComponent<Image>();
        }

        public static Image img(this GameObject @this)
        {
            return @this.GetComponent<Image>();
        }

        public static RawImage ri<T>(this T @this)
            where T : Component
        {
            return @this.GetComponent<RawImage>();
        }

        public static RawImage ri(this GameObject @this)
        {
            return @this.GetComponent<RawImage>();
        }

        //text-mesh-pro, TMP
        public static TextMeshProUGUI TMP<T>(this T @this)
            where T : Component
        {
            return @this.GetComponent<TextMeshProUGUI>();
        }

        public static TextMeshProUGUI TMP(this GameObject @this)
        {
            return @this.GetComponent<TextMeshProUGUI>();
        }

        //text
        public static Text txt<T>(this T @this)
            where T : Component
        {
            return @this.GetComponent<Text>();
        }

        public static Text txt(this GameObject @this)
        {
            return @this.GetComponent<Text>();
        }

        // HorizontalLayoutGroup
        public static HorizontalLayoutGroup hlg<T>(this T @this)
            where T : Component
        {
            return @this.GetComponent<HorizontalLayoutGroup>();
        }

        public static HorizontalLayoutGroup hlg(this GameObject @this)
        {
            return @this.GetComponent<HorizontalLayoutGroup>();
        }

        public static GameObject find_child_by_name_recursion(this GameObject parent, string name)
        {
            if (parent == null)
                return null;

            Transform res = parent.transform.Find(name);
            if (res != null)
                return res.gameObject;

            foreach (Transform child in parent.transform)
            {
                var found = child.gameObject.find_child_by_name_recursion(name);
                if (found != null)
                    return found;
            }
            return null;
        }

        // public static List<GameObject> get_children_list(this GameObject parent) {
        //   List<GameObject> children_list = new List<GameObject>();
        //   if (parent == null) return children_list;
        //   foreach (Transform child in parent.transform) {
        //     if (child == null) continue;
        //     children_list.Add(child.gameObject);
        //     get_children_list(child.gameObject);
        //   }
        //   return children_list;
        // }
        //
        // // only for one-level depth of tree
        // public static GameObject[] get_children_arr(this GameObject parent) {
        //   if (parent == null) return null;
        //   var children = new GameObject[parent.transform.childCount];
        //   int id = 0;
        //   foreach (Transform child in parent.transform) {
        //     if (child == null) continue;
        //     children[id] = child.gameObject;
        //     id++;
        //   }
        //   return children;
        // }
    }
}
