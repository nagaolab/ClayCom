Shader "Custom/VertexColor" {
   Properties {
       _MainTex ("Base (RGB)", 2D) = "white" {}
   }
   SubShader {
       Tags { "RenderType"="Opaque" }
       LOD 200

       CGPROGRAM
       #pragma surface surf Lambert

       // サーフェスShaderとしての処理.
       sampler2D _MainTex;

       struct Input {
           float2 uv_MainTex;
           float4 color : COLOR;   // 頂点カラーを受け取る.
       };

       void surf (Input IN, inout SurfaceOutput o) {
           half4 c = tex2D (_MainTex, IN.uv_MainTex);
           c *= IN.color;      // 頂点カラーの反映.
           o.Albedo = c.rgb;
           o.Alpha  = c.a;
       }
       ENDCG
   }

   Fallback "Diffuse"
}
