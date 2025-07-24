pipeline {
    agent any
    stages {
        stage("BlackDuckSecurityScan") {
            when {
                anyOf {
                    branch 'main'
                    branch pattern: "PR-\\d+", comparator: "REGEXP"
                }
            }
            steps {
                script {
                    def status = security_scan product: 'coverity',
                        coverity_url: "http://192.168.66.144:8080",
                        coverity_stream_name: "multi-test",
                        coverity_project_name: "multi-test",
                        coverity_waitForScan: false,
                        coverity_prComment_enabled: false,
                        mark_build_status: 'UNSTABLE',
                        coverity_local: true
                        
                    // Status kontrolü (plugin hatalarında build'i kırmamak için)
                   
                }
            }
        }
    }
}
