FROM adoptopenjdk/openjdk11:alpine-jre
RUN mkdir -p /opt/discovery

EXPOSE 33001

COPY target/discovery.jar /opt/discovery

ENTRYPOINT exec java $JAVA_OPTS -jar /opt/discovery/discovery.jar

